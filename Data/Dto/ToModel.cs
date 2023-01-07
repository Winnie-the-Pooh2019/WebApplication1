using WebApplication1.Data.Models;

namespace WebApplication1.Data.Dto;

public static class ToModel {
    public static Book toModel(this BookDto bookDto) => new() {
        category = new Category { name = bookDto.name },
        name = bookDto.name,
        publisher = new Publisher { name = bookDto.publisherName }
    };
}