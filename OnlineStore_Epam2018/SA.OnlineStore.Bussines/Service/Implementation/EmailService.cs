namespace SA.OnlineStore.Bussines.Service.Implementation
{
    #region Usings
        using System;
        using System.Collections.Generic;
        using SA.OnlineStore.Common.Entity;
        using SA.OnlineStore.DataAccess.Implements;
    #endregion

    public class EmailService : IEmailService
    {
        private readonly IRepository<Email> _emailRepository;

        public EmailService(IRepository<Email> emailRepository)
        {
            _emailRepository = emailRepository;
        }

        public IEnumerable<Email> GetEmailList()
        {
            return _emailRepository.GetAll();
        }

        public IEnumerable<Email> GetEmailsByUserId(int id)
        {
            throw new NotImplementedException();
        }
    }
}