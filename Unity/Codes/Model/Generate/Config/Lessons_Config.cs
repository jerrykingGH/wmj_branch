using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using ProtoBuf;

namespace ET
{
    [ProtoContract]
    [Config]
    public partial class Lessons_ConfigCategory : ProtoObject
    {
        public static Lessons_ConfigCategory Instance;
		
        [ProtoIgnore]
        [BsonIgnore]
        private Dictionary<int, Lessons_Config> dict = new Dictionary<int, Lessons_Config>();
		
        [BsonElement]
        [ProtoMember(1)]
        private List<Lessons_Config> list = new List<Lessons_Config>();
		
        public Lessons_ConfigCategory()
        {
            Instance = this;
        }
		
        public override void EndInit()
        {
            foreach (Lessons_Config config in list)
            {
                config.EndInit();
                this.dict.Add(config.Id, config);
            }            
            this.AfterEndInit();
        }
		
        public Lessons_Config Get(int id)
        {
            this.dict.TryGetValue(id, out Lessons_Config item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (Lessons_Config)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, Lessons_Config> GetAll()
        {
            return this.dict;
        }

        public Lessons_Config GetOne()
        {
            if (this.dict == null || this.dict.Count <= 0)
            {
                return null;
            }
            return this.dict.Values.GetEnumerator().Current;
        }
    }

    [ProtoContract]
	public partial class Lessons_Config: ProtoObject, IConfig
	{
		[ProtoMember(1)]
		public int Id { get; set; }
		[ProtoMember(2)]
		public string Section_Title { get; set; }
		[ProtoMember(3)]
		public string Section_Title_PinYin { get; set; }
		[ProtoMember(4)]
		public string Section_Info { get; set; }
		[ProtoMember(6)]
		public string[] ABName { get; set; }
		[ProtoMember(7)]
		public string[] BtnStyle { get; set; }
		[ProtoMember(8)]
		public string SectionPic { get; set; }

	}
}
