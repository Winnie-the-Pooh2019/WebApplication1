using WebApplication1.Data.Dto;

namespace WebApplication1.Data.Models; 

public static class ToDto {
    public static BookDto toDto(this Book book) => new() {
        name = book.name,
        categoryName = book.category.name,
        publisherName = book.publisher.name
    };
}