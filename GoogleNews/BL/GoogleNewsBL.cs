using DAL;
using DAL.Models;

namespace BL
{
    public class GoogleNewsBL
    {
        public async Task<IEnumerable<Item>>? GetItemAsync()
        {
            GoogleNewsDAL googleNewsDAL=new GoogleNewsDAL();
            return GoogleNewsDAL.GetItemAsync();
        }
        public async Task<Item>? GetAllNewsAsync()
        {

        }
    }
}