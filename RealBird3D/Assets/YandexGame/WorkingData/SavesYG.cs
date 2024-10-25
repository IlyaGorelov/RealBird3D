
namespace YG
{
    [System.Serializable]
    public class SavesYG
    {
        // "Технические сохранения" для работы плагина (Не удалять)
        public int idSave;
        public bool isFirstSession = true;
        public string language = "ru";
        public bool promptDone;

        // Тестовые сохранения для демо сцены
        // Можно удалить этот код, но тогда удалите и демо (папка Example)
        public int money = 1;                       // Можно задать полям значения по умолчанию
        public string newPlayerName = "Hello!";
        public bool[] openLevels = new bool[3];

        // Ваши сохранения

        public int record;
        public float mainSoundLevel;
        public float BGSoundLevel;
        public float NoiseSoundLevel;
        public int cash;

        public string airId;
        public string fireId;
        public string confettiId;
        public string lightningId;
        public string blowId;

        public string moreMoney2Id="a-0-0";
      public string moreMoney4Id = "a-0";
      public string moreMoney8Id = "a-0";
      public string moreMoney10Id = "a-0";
      public string booster1Id = "a-0";
       public string booster5Id = "a-0";
       public string booster10Id = "a-0";
       public string booster15Id = "a-0";

        // Поля (сохранения) можно удалять и создавать новые. При обновлении игры сохранения ломаться не должны


        // Вы можете выполнить какие то действия при загрузке сохранений
        public SavesYG()
        {
            // Допустим, задать значения по умолчанию для отдельных элементов массива

            openLevels[1] = true;
        }
    }
}
