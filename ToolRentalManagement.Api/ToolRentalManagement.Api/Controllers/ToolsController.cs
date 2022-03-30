using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ToolRentalManagement.DataAccess;
using ToolRentalManagement.Models.Tools;
using ToolRentalManagement.Services.Dtos.ToolDtos;
using ToolRentalManagement.Services.Tools;

namespace ToolRentalManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToolsController : ControllerBase
    {
        //private readonly IMapper _mapper;
        private readonly DataContext _context = new DataContext();
        public Tool tool = new Tool();
        private readonly IToolRepository _toolRepository;
        private readonly IMapper _mapper;


        public ToolsController(IToolRepository toolRepository, IMapper mapper)
        {
            _toolRepository = toolRepository;
            _mapper = mapper;
        }

        [HttpPost("addTools")]
        public async Task<ActionResult<Tool>> AddTool(AddToolDto request)
        {
            //Tool tool = _mapper.Map<Tool>(request);
            
            tool.ToolName = request.ToolName;
            tool.ItemCode = request.ItemCode;
            tool.ToolDescription = request.ToolDescription;
            tool.TotalQuantity = request.TotalQuantity;
            tool.AvailableQuantity = default(int);
            tool.RentedQuantity = default(int);
            tool.ChargesPerDay = request.ChargesPerDay;

            _context.Tools.Add(tool);
            await _context.SaveChangesAsync();
            return Ok(tool);

        }

        [HttpGet]
        public async Task<ActionResult<Tool>> GetTool(string? search)
        {
            return Ok(_toolRepository.GetTools(search));
        }

        [HttpPut]
        public async Task<ActionResult<Tool>> PutTool(string? itemCode, UpdateToolDto tool)
        {
            if (itemCode.IsNullOrEmpty())
            {
                return BadRequest("Item Code Required");
            }

            Tool tools = _toolRepository.GetToolByItemCode(itemCode);
            if (tools == null)
            {
                return NotFound("Wrong Item Code");
            }

            tools.ToolName = tool.ToolName; 
            tools.ItemCode = tool.ItemCode; 
            tools.ToolDescription = tool.ToolDescription; 
            tools.TotalQuantity = tool.TotalQuantity;
            tools.AvailableQuantity = tool.AvailableQuantity;
            tools.RentedQuantity= tool.RentedQuantity;
            tools.ChargesPerDay= tool.ChargesPerDay;

            _context.Tools.Update(tools);
            await _context.SaveChangesAsync();
            return Ok(tools);


            /*tools = _mapper.Map<Tool>(tool);
            _context.Tools.Update(tools);
            await _context.SaveChangesAsync();
            return Ok(tools);*/
        }

        [HttpDelete]
        public async Task<ActionResult<Tool>> DeleteTool(string? itemCode)
        {
            Tool tool = _toolRepository.GetToolByItemCode(itemCode);
            if (tool == null)
                return NotFound("Wrong Item Code");

            _context.Tools.Remove(tool);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
