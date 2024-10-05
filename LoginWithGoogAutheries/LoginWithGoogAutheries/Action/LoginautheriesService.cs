using Google.Apis.Auth;
using LoginWithGoogAutheries.Entity;
using LoginWithGoogAutheries.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LoginWithGoogAutheries.Action
{
    public class LoginautheriesService
    {
        private readonly AppDbContext appDbContext;
        public LoginautheriesService()
        {
            appDbContext = new AppDbContext();
        }
        public async Task<string> login([FromBody] string idToken)
        {
            try 
            {
                var payload = await GoogleJsonWebSignature.ValidateAsync(idToken);
                // Thông tin người dùng
                var email = payload.Email;
                var name = payload.Name;

                // Lưu thông tin vào cơ sở dữ liệu SQL
                // Lưu ý: bạn cần phải tạo một model và context cho Entity Framework
                using (var context = new AppDbContext())
                {
                    var user = await context.Users.SingleOrDefaultAsync(u => u.email == email);
                    if (user == null)
                    {
                        user = new User
                        {
                            
                            email= email,
                            UserName = name,
                            // Thêm các trường khác nếu cần
                        };
                        context.Users.Add(user);
                    }
                    await context.SaveChangesAsync();
                }

                return "Thanh Công";
            } 
            catch (Exception ex) {
                throw new Exception("Đăng nhập thất bại: " + ex.Message);
            }
        }
    }
}
