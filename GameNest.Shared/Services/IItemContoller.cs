using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameNest.Shared.ViewModels;
using MagicOnion;

namespace GameNest.Shared.Services
{
    public interface IItemContoller : IService<IItemContoller>
    {
        UnaryResult<ItemModel> GetItemAsync(uint itemId);
        UnaryResult<ItemModel> CreateItemAsync(string itemName);
        UnaryResult<bool> DeleteItemAsync(uint itemId);
    }
}
