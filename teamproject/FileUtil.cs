using System.Text.Json;

namespace DietDungeon
{
    public static class FileUtil
    {
        private static readonly string playerDataPath = "playerData.json";

        // player 객체를 파일에 저장
        public static void SavePlayer(Player player)
        {
            string strJson = JsonSerializer.Serialize<Player>(player, new JsonSerializerOptions() { WriteIndented = true });
            File.WriteAllText(playerDataPath, strJson);
        }

        // 파일에서 player 객체를 불러옴
        public static Player? LoadPlayer()
        {
            if (File.Exists(playerDataPath))
            {
                string json = File.ReadAllText(playerDataPath);

                if (!string.IsNullOrEmpty(json))
                {
                    Player? player = JsonSerializer.Deserialize<Player>(json);
                    return player;
                }
            }

            return null;
        }

        public static Boolean ExistPlayer()
        {
            return File.Exists(playerDataPath);
        }
    }
}
