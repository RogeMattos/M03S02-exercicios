using AutoMapper;
using FichaCadastroApi.DTO.Ficha;
using FichaCadastroApi.DTO.Telefone;
using FichaCadastroApi.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Data.Entity;
using System.Net;



namespace FichaCadastroApi.Controllers
{
    //[M3S02] Ex 04 - Criar Controller TelefoneController.cs
    [ApiController]
    [Route("api/[controller]")]
    public class TelefoneController : ControllerBase
    {
        private readonly ILogger<FichaController> _logger;
        private readonly FichaCadastroDbContext _fichaCadastroDbContext;
        private readonly IMapper _mapper;

        public TelefoneController(ILogger<FichaController> logger, FichaCadastroDbContext fichaCadastroDbContext, IMapper mapper)
        {
            _logger = logger;
            _fichaCadastroDbContext = fichaCadastroDbContext;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<TelefoneReadDTO> Post([FromBody] TelefoneCreateDTO telefoneCreateDTO)
        {
            try
            {
                var telefoneModel = _mapper.Map<TelefoneModel>(telefoneCreateDTO);

                if (_fichaCadastroDbContext.TelefoneModels.ToList().Exists(e => e.Numero == telefoneCreateDTO.Numero))
                {
                    return Conflict(new { erro = "Esse número já é Cadastrado" });
                }
                var fichaModel = _fichaCadastroDbContext.FichaModels.Where(e => e.Id == telefoneCreateDTO.FichaId).FirstOrDefault();
                telefoneModel.Ficha = fichaModel;

                _fichaCadastroDbContext.TelefoneModels.Add(telefoneModel);
                _fichaCadastroDbContext.SaveChanges();


                var telefoneReadDTO = _mapper.Map<TelefoneReadDTO>(telefoneModel);

                return StatusCode(HttpStatusCode.Created.GetHashCode(), telefoneReadDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), ex);
            }

        }

        
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<IEnumerable<TelefoneReadDTO>> Get([FromQuery] int? numero)
        {
            try
            {
                List<TelefoneModel> telefoneModels;

                if (numero == null) // email == null || email == "" 
                {
                    telefoneModels = _fichaCadastroDbContext.TelefoneModels
                                                         .ToList();
                }
                else
                {
                    telefoneModels = _fichaCadastroDbContext.TelefoneModels
                                                         //.Where(w => w.Email.Equals(email!))
                                                         .Where(w => w.Numero == numero).ToList();
                }

                var telefoneReadDTO = _mapper.Map<List<TelefoneReadDTO>>(telefoneModels);
                return Ok(telefoneReadDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }


        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<TelefoneReadDTO> Get(int id)
        {
            try
            {
                var telefoneModel = _fichaCadastroDbContext.TelefoneModels.Find(id);

                if (telefoneModel == null)
                {
                    return NotFound(new { erro = "Telefone não encontrado" });
                }

                var telefoneReadDTO = _mapper.Map<TelefoneReadDTO>(telefoneModel);
                return Ok(telefoneReadDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), ex);
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult Delete(int id)
        {
            try
            {

                var telefoneModel = _fichaCadastroDbContext.TelefoneModels.Where(w => w.Id == id).FirstOrDefault();

                if (telefoneModel == null)
                {
                    return NotFound(new { erro = "Registro não encontrado" });
                }

                _fichaCadastroDbContext.TelefoneModels.Remove(telefoneModel);
                _fichaCadastroDbContext.SaveChanges();

                return StatusCode(200);

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<TelefoneReadDTO> Put(int id, [FromBody] TelefoneUpDateDTO telefoneUpdateDTO)
        {
            try
            {
                var telefoneModel = _fichaCadastroDbContext.TelefoneModels.Where(w => w.Id == id).FirstOrDefault();

                if (telefoneModel == null)
                {
                    return NotFound(new { erro = "Registro não encontrado" });
                }

                telefoneModel = _mapper.Map(telefoneUpdateDTO, telefoneModel);

                _fichaCadastroDbContext.TelefoneModels.Update(telefoneModel);
                _fichaCadastroDbContext.SaveChanges();
                var telefoneReadDTO = _mapper.Map<TelefoneReadDTO>(telefoneModel);

                return Ok(telefoneReadDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }




    
}
