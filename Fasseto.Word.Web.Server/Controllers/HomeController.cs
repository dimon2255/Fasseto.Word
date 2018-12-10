using Fasseto.Word.Web.Server;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Fasseto.Word.Web.Server.Controllers
{
    public class HomeController : Controller
    {
        #region Private Properties

        /// <summary>
        /// Scoped application context
        /// </summary>
        protected ApplicationDBContext mDbcontext;

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="context"></param>
        public HomeController(ApplicationDBContext context)
        {
            mDbcontext = context;
        }

        #endregion

        #region Controller Actions

        public IActionResult Index()
        {

            #region DBContext Code

            //Make sure the database exists
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

            #endregion

            return View();
        }

        #endregion



    }
}
