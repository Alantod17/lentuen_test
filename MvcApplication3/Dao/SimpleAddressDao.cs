using NHibernate;
using NhibernateMappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication3.Dao
{
    public class SimpleAddressDao
    {
        private readonly ISession _nhibernateSession;

        public SimpleAddressDao(ISession nhibernateSession) { this._nhibernateSession = nhibernateSession; }

        public Address CreateAddress(Address address)
        {
            using (ITransaction tran = _nhibernateSession.BeginTransaction())
            {
                _nhibernateSession.Save(address);
                tran.Commit();
                return address;
            }
        }
    }
}