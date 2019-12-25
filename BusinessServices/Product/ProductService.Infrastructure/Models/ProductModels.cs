using AutoMapper;
using ProductService.Domain.Entities;
using ServiceCommon;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProductService.Infrastructure.Models
{
    public class AddProductModel : BaseModel
    {
        [Required(ErrorMessage = "Product Code is required")]
        public string ProductCode { get; set; }
        [Required(ErrorMessage = "Product Name is required")]
        public string ProductName { get; set; }
        [Required(ErrorMessage = "Product Amount is required")]
        public int ProductAmount { get; set; }
        [Required(ErrorMessage = "Product Price is required")]
        public decimal ProductPrice { get; set; }
        public List<Attachment> ProductPictures { get; set; }
        public string ProductProfile { get; set; }
        [Required(ErrorMessage = "ProductPrice Category is required")]
        public Guid CategoryId { get; set; }
    }

    public class UpdateProductModel : BaseModel
    {
        [Required(ErrorMessage = "Product Code is required")]
        public string ProductCode { get; set; }
        [Required(ErrorMessage = "Product Name is required")]
        public string ProductName { get; set; }
        [Required(ErrorMessage = "Product Amount is required")]
        public int ProductAmount { get; set; }
        [Required(ErrorMessage = "Product Price is required")]
        public decimal ProductPrice { get; set; }
        public List<Attachment> ProductPictures { get; set; }
        public string ProductProfile { get; set; }
        [Required(ErrorMessage = "ProductPrice Category is required")]
        public Guid CategoryId { get; set; }
    }

    public class ListProductModel : BaseModel
    {
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public int ProductAmount { get; set; }
        public decimal ProductPrice { get; set; }
        public string PicUrl { get; set; }
        public string CategoryName { get; set; }
    }

    public class QueryProductModel : BaseModel
    {
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public Guid CategoryId { get; set; }
    }

    public class GetProductModel : BaseModel
    {
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public int ProductAmount { get; set; }
        public decimal ProductPrice { get; set; }
        public string PicUrl { get; set; }
        public string CategoryName { get; set; }
    }

    public class ProductAutoMapperProfile : Profile
    {
        public ProductAutoMapperProfile()
        {
            CreateMap<AddProductModel, Product>();
            CreateMap<UpdateProductModel, Product>();
            CreateMap<Product, ListProductModel>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.CategoryName));
            CreateMap<Product, GetProductModel>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.CategoryName));
        }
    }

}
