using AutoMapper;
using FichaCadastroApi.DTO.Ficha;
using FichaCadastroApi.Model;
using Microsoft.AspNetCore.Mvc;
using System.Net;


namespace FichaCadastroApi.Controllers
{

    [ApiController]
    [Route("api/[controller)")]
    public class FichaController : ControllerBase
    {
        private readonly ILogger<FichaController> _logger;
        private readonly FichaCadastroDbContext _fichaCadastroDbContext;
        private readonly IMapper _mapper;

        public FichaController(ILogger<FichaController> logger, FichaCadastroDbContext fichaCadastroDbContext, IMapper mapper)
        {
            _logger = logger;
            _fichaCadastroDbContext = fichaCadastroDbContext;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<FichaReadDTO> Post([FromBody] FichaCreateDTO fichaCreateDTO)
        {
            try
            {
                var fichaModel = _mapper.Map<FichaModel>(fichaCreateDTO);

                if (_fichaCadastroDbContext.FichaModels.ToList().Exists(e => e.Email == fichaCreateDTO.EmailInformado))
                {
                    return Conflict(new { erro = "E-mail Cadastrado" });
                }

                _fichaCadastroDbContext.FichaModels.Add(fichaModel);
                _fichaCadastroDbContext.SaveChanges();


                var fichaReadDTO = _mapper.Map<FichaReadDTO>(fichaModel);

                return StatusCode(HttpStatusCode.Created.GetHashCode(), fichaReadDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), ex);
            }

        }

    }
}
