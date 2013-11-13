using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication3.Controllers
{
    public class AddressController : Controller
    {
        //
        // GET: /Address/

        Dao.SimpleAddressDao _addressDao = new Dao.SimpleAddressDao(MvcApplication.NHibernateSessionFactory.GetCurrentSession());
        public ActionResult Index()
        {
            _addressDao.CreateAddress(new NhibernateMappings.Address{
                Address1 = "Ad1", Address2 = "Ad2", City = "CHCH", State = "AL", Zipcode = "3245"
            });
            return View();
        }

    }
}
