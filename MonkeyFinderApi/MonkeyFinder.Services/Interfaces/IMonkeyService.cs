using MonkeyFinder.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonkeyFinder.Core.Entities;
using System.Collections;

namespace MonkeyFinder.Services.Interfaces
{
    public interface IMonkeyService
    {
        Task<IEnumerable<MonkeyDto>> GetMonkeysAsync();
        Task<IEnumerable<MonkeyDto>> SearchMonkeyByIdAsync(int id);
        Task <IEnumerable<MonkeyDto>> AddMonkeysAsync(Monkey monkey);
        Task<IEnumerable<MonkeyDto>> UpdateMonkeysAsync(Monkey monkey);
        Task<IEnumerable<MonkeyDto>> DeleteMonkeysAsync(Monkey monkey);



    }
}
