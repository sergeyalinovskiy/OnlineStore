namespace OnlineStore_Epam2018.Controllers
{
    #region Usings
        using OnlineStore_Epam2018.Models;
        using OnlineStore_Epam2018.RoleAttribut;
        using SA.OnlineStore.Bussines.Service;
        using SA.OnlineStore.Common.Entity;
        using System;
        using System.Collections.Generic;
        using System.Linq;
        using System.Web.Mvc;
     #endregion
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IEmailService _emailService;
        private readonly IPhoneService _phoneService;
        private readonly IRoleService _roleService;

        public UserController(IUserService userService, IEmailService emailService, IPhoneService phoneService, IRoleService roleService)
        {
            if (userService == null)
            {
                throw new ArgumentNullException("userService");
            }
            if (emailService == null)
            {
                throw new ArgumentNullException("emailService");
            }
            if (phoneService == null)
            {
                throw new ArgumentNullException("phoneService");
            }
            if (roleService == null)
            {
                throw new ArgumentNullException("roleService");
            }
            _userService = userService;
            _emailService = emailService;
            _phoneService = phoneService;
            _roleService = roleService;
        }
         [Admin]

        public ActionResult Create()
        {
            var viewModel = new UserViewModel()
            {
               Roles=_roleService.GetRoleList(),
               Phones = _phoneService.GetPhoneList(),
               Emails = _emailService.GetEmailList()
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserViewModel model)
        {
            if(this.ModelState.IsValid)
            {
                model.Roles = _roleService.GetRoleList();
                var user = this.ConvertToBussinesCreateModel(model);
                _userService.SaveUser(user);
                return RedirectToAction("GetUserList");
            }
            else
            {
                ModelState.AddModelError("", "Exception");
            }
            model.Roles = _roleService.GetRoleList();
            return View(model);

        }

        [Admin]
        public ActionResult GetUser(int id)
        {
            if (id >0)
            {
            var user = _userService.GetUserById(id);
            }
            return View();
        }

        public ActionResult GetUserAutorithInfo()
        {
            var userr = HttpContext.User.Identity.Name;
            int userId = _userService.GetUserByLogin(userr).UserId;
            var user = ConvertToViewModel(_userService.GetUserById(userId));

            return View(user);
        }
        [Admin]
        public ActionResult GetUserList()
        {
            var users = ConvertListToViewModel(_userService.GetUsersList());
            return View(users);
        }
        [Admin]
        public ActionResult Delete (int id)
        {
            _userService.DeleteUserByUserId(id);
            return RedirectToAction("GetUserList");
        }

        public IEnumerable<UserViewModel> ConvertListToViewModel(IEnumerable<User> models)
        {
            List<UserViewModel> users = new List<UserViewModel>();
            foreach (User item in models)
            {
                users.Add(ConvertToViewModel(item));
            }
            return users;
        }

        public UserViewModel ConvertToViewModel(User model)
        {
            var role = _roleService.GetRoleList().Where(c => c.RoleId == model.Role.RoleId).FirstOrDefault();
            return new UserViewModel()
            {
                UserId = model.UserId,
                Login = model.Login,
                Password = model.Password,
                Name = model.Name,
                LastName = model.LastName,
                EmailAddress = model.Email.EmailAddress,
                PhoneNumber = model.Phone.PhoneNumber,
                Role = new Role()
                {
                    RoleId = role.RoleId,
                    Name = role.Name
                },
                Roles = _roleService.GetRoleList()
            };
        }

        public User ConvertToBussinesModel(UserViewModel model)
        {
            var role = _roleService.GetRoleList().Where(c => c.RoleId == model.Role.RoleId).FirstOrDefault();
            return new User()
            {
                UserId = model.UserId,
                Login = model.Login,
                Password = model.Password,
                Name = model.Name,
                LastName = model.LastName,
                Role = new Role()
                {
                    RoleId= role.RoleId,
                    Name=role.Name
                },
                Phone = new Phone()
                {
                   PhoneNumber = model.PhoneNumber,
                    UserId = model.UserId
                },
                Email = new Email()
                {
                    EmailAddress = model.EmailAddress,
                    UserId = model.UserId
                }
            };
        }

        public User ConvertToBussinesCreateModel(UserViewModel model)
        {
            var role = _roleService.GetRoleList().Where(c => c.Name== model.RoleName).FirstOrDefault();
            return new User()
            {
                UserId = model.UserId,
                Login = model.Login,
                Password = model.Password,
                Name = model.Name,
                LastName = model.LastName,
                Role = new Role()
                {
                    RoleId = role.RoleId,
                    Name = role.Name
                },
                Phone = new Phone()
                {
                    PhoneNumber = model.PhoneNumber,
                    UserId = model.UserId
                },
                Email = new Email()
                {
                    EmailAddress = model.EmailAddress,
                    UserId = model.UserId
                }
            };
        }

        public ActionResult Details(int id)
        {
            var user = ConvertToViewModel(this._userService.GetUserById(id));
            return View(user);
        }

        public ActionResult EditUserAutorithation(int id)
        {
            var user = ConvertToViewModel(this._userService.GetUserById(id));
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditUserAutorithation(UserViewModel model)
        {
            if (model.Name != null && model.Password != null && model.LastName != null && model.Login != null)
            {
                model.RoleName = model.Role.Name;
                var user = this.ConvertToBussinesCreateModel(model);
                _userService.SaveUser(user);
                return RedirectToAction("GetUserAutorithInfo", new { Id = model.UserId });
            }
            else
            {
                ModelState.AddModelError("", "Exception");
            }
            model.Roles = _roleService.GetRoleList();
            return View(model);
            
   
        }

        public ActionResult Edit(int id)
        {
            var user = ConvertToViewModel(this._userService.GetUserById(id));
            return View(user);
        }
            
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UserViewModel model)
        {
            if (model.Name!=null && model.Password!=null && model.LastName!=null && model.Login!=null)
            {
                model.Roles = _roleService.GetRoleList();
                var user = this.ConvertToBussinesModel(model);
                _userService.SaveUser(user);
                return RedirectToAction("Details", new { Id = model.UserId });
            }
            else
            {
                ModelState.AddModelError("", "Exception");
            }
            model.Roles = _roleService.GetRoleList();
            return View(model);
        }
    }
}