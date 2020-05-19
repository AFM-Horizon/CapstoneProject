using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CapstoneProject.DataAccess.Subject
{
    /// <summary>
    ///This is a concrete implementation of the ISubjectRepository,
    ///This layer will be changed out when the data access changes to a different method
    ///Think of it as a modular component in the system that can be "plugged in"
    /// </summary>
    class SubjectWebscraperRepository : ISubjectRepository
    {
        public Task<IEnumerable<Subject>> GetAllAsync()
        {
            //Get Data From Web Scraper
            throw new NotImplementedException();
        }

        public Task<Subject> GetByIdAsync(string id)
        {
            //Get Data From Web Scraper
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Subject>> FindAsync(Expression<Func<Subject, bool>> predicate)
        {
            //Get Data From Web Scraper
            throw new NotImplementedException();
        }
    }
}