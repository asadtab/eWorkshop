using AutoMapper;
using eWorkshop.Model;
using eWorkshop.Model.Requests;
using eWorkshop.Model.SearchObject;
using eWorkshop.Services;
using eWorkshop.Services.Database;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eWorkshop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class KorisniciController : BaseCRUDController<KorisniciVM, KorisniciSearchObject, KorisniciInsertRequest, KorisniciUpdateRequest>
    {
        private IKorisniciService KorisniciService { get; set; }
        ILogger<RadniZadatakController> Logger;

        public KorisniciController(ILogger<RadniZadatakController> logger, IKorisniciService service) : base(service)
        {
            KorisniciService = service;
            Logger = logger;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var user = await KorisniciService.Login(request.username, request.password);


            if (user == null) {
                return BadRequest("Pogrešan login");
            }

            return Ok(new {token = user});
        }

        [HttpPost("Registracija")]
        public async Task<IActionResult> Registracija(KorisniciInsertRequest request)
        {
            try
            {
                var korisnikVM = await KorisniciService.Register(request);
                return Ok(korisnikVM); // Return the KorisniciVM data
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("PromijeniPassword")]
        public async Task<IActionResult> PromijeniPassword(PromjeniPasswordRequest request)
        {
            try
            {
                var userVM = await KorisniciService.UpdatePassword(request);

                if (userVM == null)
                    return NotFound(new { message = "Korisnik nije pronađen." });

                return Ok(userVM);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = $"Greška prilikom promjene lozinke: {ex.Message}" });
            }
        }




    }
}
