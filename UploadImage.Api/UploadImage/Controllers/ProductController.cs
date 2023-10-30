using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UploadImage.Models.Domain;
using UploadImage.Models;
using UploadImage.Repository.Abstract;

namespace UploadImage.Controllers
{
    [Route("api/[controller]/{action}")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IFileService _fileService;
        private readonly IProductRepository _productRepo;
        public ProductController(IFileService fs, IProductRepository productRepo)
        {
            _fileService = fs;
            _productRepo = productRepo;
        }

        [HttpPost]
        public IActionResult Add([FromForm] Product model)
        {
            var status = new Status();
            if (!ModelState.IsValid)
            {
                status.StatusCode = 0;
                status.Message = "Please pass the valid data";
                return Ok(status);
            }
            if (model.ImageFile != null)
            {
                var fileResult = _fileService.SaveImage(model.ImageFile);
                if (fileResult.Item1 == 1)
                {
                    model.ProductImage = fileResult.Item2; // getting name of image
                }

                try
                {
                    var productResult = _productRepo.Add(model);
                    if (productResult)
                    {
                        status.StatusCode = 1;
                        status.Message = "Added successfully";
                    }
                    else
                    {
                        status.StatusCode = 0;
                        status.Message = "Error on adding product";
                    }
                }
                catch (Exception ex)
                {
                    // Log the exception
                    status.StatusCode = 0;
                    status.Message = "Error on adding product: " + ex.Message;
                }
            }
            return Ok(status);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_productRepo.GetAll());
        }
    }
}
