namespace AuthProject.Models;

   public record PasswordDto(
       string Salt,
       string PasswordHash
       );


