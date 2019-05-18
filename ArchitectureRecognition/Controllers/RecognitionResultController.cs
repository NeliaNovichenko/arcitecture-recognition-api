using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ArchitectureRecognition.Models.RecognitionResult;
using ArchitectureRecognition.Services.Data.Entities;
using ArchitectureRecognition.Services.RecognitionResult;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Drawing.Imaging;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace ArchitectureRecognition.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecognitionResultController : ControllerBase
    {
        private readonly IRecognitionResultService _service;
        private readonly IRecognitionResultMapper _mapper;
        private readonly IHostingEnvironment _env;

        public RecognitionResultController(IRecognitionResultService service, IRecognitionResultMapper mapper, IHostingEnvironment env)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _env = env;
        }

        [HttpGet()]
        public async Task<ActionResult<RecognitionResultDto[]>> GetAllAsync()
        {
            string userId = User.FindFirst(JwtRegisteredClaimNames.Sub).Value;
            //string userId = 0;

            List<RecognitionResult> recognitionResults = await _service.GetAllAsync(userId);

            if (recognitionResults == null || !recognitionResults.Any())
            {
                return Ok(Array.Empty<RecognitionResult>());
            }

            RecognitionResultDto[] recognitionResultDtos = recognitionResults.Select(recognitionResult => _mapper.MapToDto(recognitionResult)).ToArray();
            return Ok(recognitionResultDtos);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<RecognitionResultDto>> GetByIdAsync(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            RecognitionResult recognitionResult = await _service.GetByIdAsync(id);

            if (recognitionResult == null)
            {
                return NotFound();
            }

            RecognitionResultDto dto = _mapper.MapToDto(recognitionResult);
            return Ok(dto);
        }

        [HttpPost()]
        public async Task<ActionResult<RecognitionResultDto>> CreateAsync([FromForm]SaveRecognitionDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var resultDto = JsonConvert.DeserializeObject<RecognitionResultDto>(dto.resultDto);
            IFormFile file = dto.file;

            string userId = User.FindFirst(JwtRegisteredClaimNames.Sub).Value;

            var PathWithFolderName = Path.Combine(Directory.GetCurrentDirectory(), "StaticFiles//");

            if (!Directory.Exists(PathWithFolderName))
            {
                // Try to create the directory.
                DirectoryInfo di = Directory.CreateDirectory(PathWithFolderName);
            }

            var fileNameExtention = file.FileName.Split(".");

            var imagePath = string.Join("", fileNameExtention.Take(fileNameExtention.Length - 1))
                + Guid.NewGuid() 
                + "."
                + fileNameExtention[fileNameExtention.Length - 1];

            using (var fileStream = new FileStream(PathWithFolderName+imagePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            resultDto.ImagePath = "/images/" + imagePath;
            var task = _mapper.MapToEntity(resultDto, userId);
            var created = await _service.AddRecognitionResultAsync(task);

            return Ok(_mapper.MapToDto(created));
            //return CreatedAtAction(nameof(GetByIdAsync), new { id = created.Id }, _mapper.MapToDto(created));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAsync([Range(1, int.MaxValue)]int id, [FromBody]RecognitionResultDto taskDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            string userId = User.FindFirst(JwtRegisteredClaimNames.Sub).Value;

            RecognitionResult recognitionResult = _mapper.MapToEntity(taskDto, userId);
            await _service.UpdateRecognitionResultAsync(id, recognitionResult);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync([Range(1, int.MaxValue)]int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _service.DeleteAsync(id);

            return NoContent();
        }
    }
}