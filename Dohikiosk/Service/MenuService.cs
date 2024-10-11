using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json; //간단하고 성능이 더좋음 newtonsoft는 기능이 다양해서 좋으나 여기서는 그정도의 기능을 쓰지않음
using Dohikiosk.Entity;

namespace Dohikiosk.Service
{
    // (file으로 기본 양식 변경 db쓰는건 추후고려)

    public class MenuService
    {
        private const string MenuFilePath = @"Data\menuEntity.json"; // 프로젝트 루트에서 Data 폴더로 이동

        //JSON이든 뭐든 저장장치 하나만들어서 해놓기  
        public List<MenuEntity> menuLoad()
        {
            Console.WriteLine("Current Directory: " + Directory.GetCurrentDirectory());

            var fullPath = Path.Combine(Directory.GetCurrentDirectory(), MenuFilePath);

            Console.WriteLine("Current Directory: " + fullPath);
            if (!File.Exists(MenuFilePath))
            {
                throw new FileNotFoundException("Menu file not found.", fullPath);
            }
            var jsonFromFile = File.ReadAllText(fullPath, Encoding.UTF8);
            return JsonSerializer.Deserialize<List<MenuEntity>>(jsonFromFile);

        }
    }
}
