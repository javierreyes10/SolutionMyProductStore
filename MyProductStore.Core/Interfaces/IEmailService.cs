using System.Threading.Tasks;

namespace MyProductStore.Core.Interfaces
{
    public interface IEmailService
    {
        Task SendAsync(string subject, string html, string to, string from = null);
    }
}
