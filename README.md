# CapstoneProject
 Holmesglen Capstone Project
 
Hi All.

Some notes regarding the Repository and Unit of work:
I have created the SubjectRepository and UnitOfWork to allow easier development of controller and view code going forward.
```C Sharp
public class SubjectRepository : ISubjectRepository
    {
        private readonly IHostingEnvironment _environment;

        public SubjectRepository(IHostingEnvironment environment)
        {
            _environment = environment;
        }

        public Task<IEnumerable<Subject>> GetAllAsync()
        {
            return Task.FromResult(GetScopeDataFeedJsonData());
        }

        public Task<Subject> GetByIdAsync(string id)
        {
            return Task.FromResult(GetSingleScopeSubjectByModuleCode(id));
        }
```

Qiao has provided us with the ScopeDataFeed.json mockup data and I have created a json deserializer so that we can access this through the Repository and UnitOfWork.

```C Sharp
 //Returns a single TGA subject object based on the module code
        private Subject GetSingleScopeSubjectByModuleCode(string id)
        {
            Subject subjectToReturn = null;

            foreach (var subjectTransferObject in GetScopeDataFeedJsonData())
            {
                if (subjectTransferObject.ModuleCode == id)
                {
                    subjectToReturn = subjectTransferObject;
                }
            }

            return subjectToReturn;
        }

        //Returns a list of all TGA subject objects from the Mock Scope Data Feed
        private IEnumerable<Subject> GetScopeDataFeedJsonData()
        {
            string contentPath = _environment.WebRootPath;

            var json = File.ReadAllText(contentPath + "/ScopeDataFeed.json");
            var subjectList = JsonConvert.DeserializeObject<IEnumerable<Subject>>(json);
            return subjectList;
        }
```

You can see an example of how to call and use it in the Subject Controller below.  

```C Sharp
private readonly IUnitOfWork _unit;

        public SubjectController(IUnitOfWork unit)
        {
            _unit = unit;
        }

        [HttpGet]
        public async Task<IActionResult> SubjectList()
        {
            //This returns a list of subjects that we can use to populate the view
            var subjectList = await _unit.SubjectRepository.GetAllAsync();

            return View(nameof(SubjectList), subjectList);
        }

        [HttpGet]
        public async Task<IActionResult> SubjectDetails(string moduleCode)
        {
            //this retrieves the info for a single subject given a module code
            var subject = await _unit.SubjectRepository.GetByIdAsync(moduleCode);

            return View(nameof(SubjectDetails), subject);
        }
```

The repository is not strictly nesscesary, however it will provide an easy abstraction to work against rather than relying directly on the json data.  That way later on when the A.P.I is available it will be a cinch to switch over to that and none of the controller code should (thoretically) need to change. :)
