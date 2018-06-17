Create new Folder;

Clone repository in this folder

Open SQLManagmentStudio Connect to server WindowsAuthentication and create new empty DB.

Open OnlineStore\OnlineStoreDB\script  Specify the name of the database in the first line of the script.
execute the script

Open: OnlineStore\OnlineStore_Epam2018\SA.OnlineStore.WCF\StaticList\MakingPublicityList.cs and 
write in  static string ProjectFolder = "NameYourNewFolder";
Open: OnlineStore\OnlineStore_Epam2018\SA.OnlineStore.Common\Const\DbConstant.FolderName and 
write in    string FolderName = "NameYourNewFolder";

Open: OnlineStore\OnlineStore_Epam2018\OnlineStore_Epam2018\Web.config and change connectionString

Update ServiceReference in DataAccess