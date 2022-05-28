namespace Mc2.CrudTest.Domain.DTO;
public record class BaseResponseDTO(bool IsSuccess, string[] Errors);