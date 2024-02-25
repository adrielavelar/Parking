using Microsoft.AspNetCore.Mvc;
using Parking.Application.Interfaces;
using Parking.Domain.Enums;

namespace Parking.Controllers
{
    [ApiController]
    [Route("api/vacancies")]
    public class VacancyController : ControllerBase
    {
        private readonly IVacancyService _vacancyService;

        public VacancyController(IVacancyService vacancyService)
        {
            _vacancyService = vacancyService;
        }

        /// <summary>
        /// retorna todas as informações do estacionamento
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }

        /// <summary>
        /// retorna total de vagas livres
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("empty")]
        public async Task<IActionResult> GetEmptyVacancies()
        {
            var emptyVacancies = await _vacancyService.GetEmptyVacancies();

            return Ok(emptyVacancies);
        }

        /// <summary>
        /// retorna total de vagas no estacionamento
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("total")]
        public async Task<IActionResult> GetTotalVacancies()
        {
            var total = await _vacancyService.GetTotalVacancies();

            return Ok(total);
        }

        /// <summary>
        /// verifica se o estacionamento está cheio ou vazio
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("status")]
        public async Task<IActionResult> GetStatus()
        {
            var status = await _vacancyService.GetStatus();

            return Ok(status);
        }

        /// <summary>
        /// verifica se determinado tipo de vaga está cheia
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("status/type")]
        public async Task<IActionResult> GetStatusByType(TypeEnum type)
        {
            var result = await _vacancyService.IsVacanciesFull(type);

            return Ok(result);
        }

        /// <summary>
        /// retorna a quantidade de vans ocupadas
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("vans")]
        public async Task<IActionResult> GetVanBusyVacancies()
        {
            var quantity = await _vacancyService.GetVanBusyVacancies();

            return Ok(quantity);
        }
    }
}
