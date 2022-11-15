// using DDCatalogue.Model;
// using DDCatalogue.Model.Creatures;
// using Microsoft.AspNetCore.JsonPatch;
// using Microsoft.AspNetCore.Mvc;
// using System.Collections.Generic;
// using System.Linq;
// using System;
// using System.Security.Cryptography.X509Certificates;
// using System.Linq.Expressions;
// using DDCatalogue.Model.Locations;

// namespace DDCatalogue.Controllers
// {
//     [Route("[controller]")]
//     [ApiController]
//     public class BuildingsController : GenericController<Building>
//     {
//         // GET: api/Building
//         [HttpGet("Locale/{localeId}")]
//         public ActionResult<List<Building>> GetBuildingsFromLocale(Guid localeId, [FromQuery] ListingParameters<Building> parameters)
//         {
//             parameters.Filter = x => x.Locale.Id.Equals(localeId);
//             return UnitOfWork.Repository.Get(parameters).ToList();
//         }

//         // GET: api/Building/5
//         [HttpGet("{id}")]
//         public ActionResult<Building> GetBuildingById(Guid id, [FromQuery] string include)
//         {
//             return GetGen(id, include);
//         }

//         [HttpPatch("{id}")]
//         public ActionResult<Building> PatchBuilding(Guid id, [FromBody] JsonPatchDocument<Building> patchDoc, [FromQuery] string include)
//         {
//             return PatchGen(id, patchDoc, include);
//         }

//         // PUT: api/Building/5
//         [HttpPut("{id}")]
//         public IActionResult PutBuilding(Guid id, Building building)
//         {
//             return PutGen(id, building);
//         }

//         // POST: api/Building
//         [HttpPost]
//         public ActionResult<Building> PostBuilding(Building building)
//         {
//             return PostGen(building);
//         }

//         // DELETE: api/Building/5
//         [HttpDelete("{id}")]
//         public ActionResult<Building> DeleteBuilding(Guid id)
//         {
//             return DeleteGen(id);
//         }

//         // [HttpGet("[action]")]
//         // public ActionResult<dynamic> GetTable()
//         // {
//         //     dynamic buildings = UnitOfWork.Repository.Get()
//         //         .Select(m => new
//         //         {
//         //             id = m.Id,
//         //             name = m.Name
//         //         }).ToList();
//         //     return buildings;
//         // }

//         [HttpGet("[action]/{name}")]
//         public ActionResult<List<string>> GetEnum(string name)
//         {
//             return GetEnumGen(name);
//         }
//     }
// }
