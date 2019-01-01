using Fasseto.Word.Core;
using Fasseto.Word.Web.Server;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Fasseto.Word.Web.Server.Controllers
{
    public class HomeController : Controller
    {
        #region Protected Properties

        /// <summary>
        /// Scoped application context
        /// </summary>
        protected ApplicationDBContext mDbcontext;

        /// <summary>
        /// The Manager for handling users, creation, deletion, roles, searching...
        /// </summary>
        protected UserManager<ApplicationUser> mUserManager;

        /// <summary>
        /// The manager for handling signing in and out of users
        /// </summary>
        protected SignInManager<ApplicationUser> mSignInManager;

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="context">Database Context Connection</param>
        /// <param name="userManager">Manager for users</param>
        /// <param name="signInManager">Manager for signing in/out of users</param>
        public HomeController(ApplicationDBContext context, 
                              UserManager<ApplicationUser> userManager,
                              SignInManager<ApplicationUser> signInManager)
        {
            mDbcontext = context;
            mUserManager = userManager;
            mSignInManager = signInManager;
        }

        #endregion

        #region Controller Actions

        /// <summary>
        /// Index Action
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
             //Create DB if it doesn't exist, if exists ignore the call
            mDbcontext.Database.EnsureCreated();
            
            if (!mDbcontext.Settings.Any())
            {
                mDbcontext.Settings.Add(new SettingsDataModel()
                {
                    Name = "BackgroundColor",
                    Value = "Red"
                });

                var numOfSettingsLocally = mDbcontext.Settings.Local.Count();
                var numOfSettingsDatabase = mDbcontext.Settings.Count();

                var firstLOcal = mDbcontext.Settings.Local.FirstOrDefault();
                var firstDatabase = mDbcontext.Settings.FirstOrDefault();

                mDbcontext.SaveChanges();

                numOfSettingsLocally = mDbcontext.Settings.Local.Count();
                numOfSettingsDatabase = mDbcontext.Settings.Count();

                firstLOcal = mDbcontext.Settings.Local.FirstOrDefault();
                firstDatabase = mDbcontext.Settings.FirstOrDefault();
            }

 
            return View();
        }

        /// <summary>
        /// Create a single user for now
        /// </summary>
        /// <returns></returns>
        [Route(WebRoutes.CreateUser)]
        public async Task<IActionResult> CreateUserAsync()
        {
            var result = await mUserManager.CreateAsync(new ApplicationUser()
            {
                UserName = "dimon2255",
                Email = "dimon2255@inbox.ru",
                Firstname = "Dimitri",
                Lastname = "Pankov"
            }, "password");

            if(result.Succeeded)
               return Content("User was created", "text/html");

            return Content("Unable to create User", "text/html");
        }
     
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Route(WebRoutes.SignOutUser)]
        public async Task<IActionResult> SignOutAsync()
        {
            await mSignInManager.SignOutAsync();
            return Content("done");
        }

        /// <summary>
        ///Auto-Login Page
        /// </summary>
        /// <param name="returnUrl">If login successful, URL to return to</param>
        /// <returns></returns>
        [Route(WebRoutes.LoginUser)]
        public async Task<IActionResult> LoginAsyn(string returnUrl)
        {
            //Sign out user
            await mSignInManager.SignOutAsync();

            //try signing in the user
            var result = await mSignInManager.PasswordSignInAsync("Dimitri" , "password", true, false);

            if (result.Succeeded)
            {
                //We have no return URL
                if (string.IsNullOrEmpty(returnUrl))
                    return RedirectToAction(nameof(Index));

                //Otherwise, go to the return URL
                return Redirect(returnUrl);
            }

            return Content("Testing", "text/html");
        }

        #endregion



    }
}
