using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using ProtoBuf;

namespace ET
{
    [ProtoContract]
    [Config]
    public partial class Contents_ConfigCategory : ProtoObject
    {
        public static Contents_ConfigCategory Instance;
		
        [ProtoIgnore]
        [BsonIgnore]
        private Dictionary<int, Contents_Config> dict = new Dictionary<int, Contents_Config>();
		
        [BsonElement]
        [ProtoMember(1)]
        private List<Contents_Config> list = new List<Contents_Config>();
		
        public Contents_ConfigCategory()
        {
            Instance = this;
        }
		
        public override void EndInit()
        {
            foreach (Contents_Config config in list)
            {
                config.EndInit();
                this.dict.Add(config.Id, config);
            }            
            this.AfterEndInit();
        }
		
        public Contents_Config Get(int id)
        {
            this.dict.TryGetValue(id, out Contents_Config item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (Contents_Config)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, Contents_Config> GetAll()
        {
            return this.dict;
        }

        public Contents_Config GetOne()
        {
            if (this.dict == null || this.dict.Count <= 0)
            {
                return null;
            }
            return this.dict.Values.GetEnumerator().Current;
        }
    }

    [ProtoContract]
	public partial class Contents_Config: ProtoObject, IConfig
	{
		[ProtoMember(1)]
		public int Id { get; set; }
		[ProtoMember(3)]
		public string Name { get; set; }
		[ProtoMember(4)]
		public int Grade { get; set; }
		[ProtoMember(5)]
		public int Term { get; set; }
		[ProtoMember(6)]
		public int Num { get; set; }
		[ProtoMember(7)]
		public string FengMianPath { get; set; }
		[ProtoMember(8)]
		public string TypeName { get; set; }
		[ProtoMember(10)]
		public int[] Sections { get; set; }
		[ProtoMember(11)]
		public string[] ABBundles { get; set; }

	}
}
