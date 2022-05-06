using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace ET
{

    public static class YinShiYuJianKang_Extends
    {
        public static void InitData(this YinShiYuJianKang_Component self)
        {
            self.InfoStru = new YaoShiTongYuan();
            self.InfoStru.PicInfo = new List<string>();

            switch (GSRunningData.YinShiYuJianKang_SelectedIndex)
            {
                case 1:
                    self.InfoStru.Name = "玉米";
                    self.InfoStru.Info = "味甘，性平，归脾、胃经，它有调理脾胃、降脂降压的作用，也有刺激胃肠蠕动、促进排便的作用，可防治便秘。";

                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}植株");
                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}的生长环境");
                    self.InfoStru.PicInfo.Add("玉米入菜");
                    break;
                case 2:
                    self.InfoStru.Name = "芝麻";
                    self.InfoStru.Info = "芝麻主要有黑、白两种，原称胡麻，是我国四大食用油料作物之一，自古我国就有许多用芝麻制作的美味佳肴。芝麻味甘，性平，归肝、肾、肺经。且黑芝麻具有滋养肝肾、乌发的作用。此外芝麻还有很好的润肠通便的作用。";

                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}植株");
                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}的生长环境");
                    self.InfoStru.PicInfo.Add("黑芝麻馅汤圆");
                    break;
                case 3:
                    self.InfoStru.Name = "黄豆";
                    self.InfoStru.Info = "黄豆又名大豆，味甘，性平，归脾、大肠经，具有益气养血、健脾宽中、解毒消肿的功效。黄豆在全国各地普遍种植，以东北黄豆质量最优。黄豆所含蛋白质在量和质上均可与动物蛋白相媲美，所以又有“植物肉”之美称。";

                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}植株");
                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}的生长环境");
                    self.InfoStru.PicInfo.Add("黄豆豆浆");
                    break;
                case 4:
                    self.InfoStru.Name = "鸡蛋";
                    self.InfoStru.Info = "味甘，性平，归肺、脾、胃经，有滋阴补气、润肺利咽、清热解毒的作用，能健脑益智，促进大脑及身体发育。";

                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}");
                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}的来源");
                    self.InfoStru.PicInfo.Add("煎鸡蛋");
                    break;
                case 5:
                    self.InfoStru.Name = "菠菜";
                    self.InfoStru.Info = "菠菜味甘，性平，归肝、胃、大肠、小肠经，有解热毒、利肠胃的作用，可以缓解便秘、眼目昏花等病症，还能促进人体对食物的消化吸收。";

                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}植株");
                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}的生长环境");
                    self.InfoStru.PicInfo.Add("蒜香菠菜");
                    break;
                case 6:
                    self.InfoStru.Name = "甘蔗";
                    self.InfoStru.Info = "又名“蔗”，味甘，性凉，归肺、脾、胃经，有清热生津、润燥和中的作用，可用于干咳、便秘、反胃等病症，还有解酒功效。";

                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}植株");
                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}的生长环境");
                    self.InfoStru.PicInfo.Add("甘蔗饮品");
                    break;
                case 7:
                    self.InfoStru.Name = "糯米";
                    self.InfoStru.Info = "味甘，性温，归脾、胃、肺经，有补中益气、健脾止泻等作用，对食欲不佳、腹胀腹泻等情况可起到缓解作用。糯米在北方多称“江米”。";

                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}植株");
                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}成熟");
                    self.InfoStru.PicInfo.Add("糯米制作粽子");
                    break;
                case 8:
                    self.InfoStru.Name = "蚕豆";
                    self.InfoStru.Info = "味甘、微辛，性平，归脾、胃经，有健脾利水、解毒消肿的作用，还能促进大肠蠕动，保持大便通畅，起到排毒的作用。";

                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}植株");
                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}的生长环境");
                    self.InfoStru.PicInfo.Add("五香蚕豆");
                    break;
                case 9:
                    self.InfoStru.Name = "鸭蛋";
                    self.InfoStru.Info = "味甘、咸，性凉，归肺、肾经，能滋阴清肺、补心止热，还可以滋养身体、强壮体格，而且对贫血有一定的预防作用。";

                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}");
                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}的来源");
                    self.InfoStru.PicInfo.Add("咸鸭蛋");
                    break;
                case 10:
                    self.InfoStru.Name = "黄瓜";
                    self.InfoStru.Info = "味甘，性凉，归脾、胃、大肠经，有清热解毒、利湿消肿、养颜护肤之功效，适用于中暑、小便不利、胃口差、食少。食用黄瓜还能促进胃肠蠕动，防止便秘，加速体内有害物质的排出。";

                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}植株");
                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}的生长环境");
                    self.InfoStru.PicInfo.Add("凉拌黄瓜");
                    break;
                case 11:
                    self.InfoStru.Name = "鹌鹑蛋";
                    self.InfoStru.Info = "味甘，性平，归心、脾经，补气血、强身健脑、安神志，是各种虚弱病者或老人、儿童、孕妇的理想滋补食品，对高血压病人也有一定的调补作用。";

                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}");
                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}的来源");
                    self.InfoStru.PicInfo.Add("卤制鹌鹑蛋");
                    break;
                case 12:
                    self.InfoStru.Name = "茼蒿";
                    self.InfoStru.Info = "味辛、甘，性凉，归心、脾、胃经，具有清心、养胃、化痰的作用，适用于脾胃不和、食欲不振、痰热咳嗽等病症。";

                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}植株");
                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}的生长环境");
                    self.InfoStru.PicInfo.Add("凉拌茼蒿");
                    break;
                case 13:
                    self.InfoStru.Name = "燕麦";
                    self.InfoStru.Info = "味甘，性平，归脾、胃经，补益脾肾、润肠通便，对糖尿病患者具有很好的降糖作用，能够促进胃肠蠕动，使排便通畅，减少便秘的发生。中老年人经常使用燕麦，对防治高脂血症、心脑血管疾病有一定的作用。";

                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}植株");
                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}的生长环境");
                    self.InfoStru.PicInfo.Add("燕麦粥");
                    break;
                case 14:
                    self.InfoStru.Name = "绿豆";
                    self.InfoStru.Info = "味甘，性寒，归心、肝、胃经，有清热消暑、利水解毒的作用，是众所周知的夏日解暑良品，对高脂血症和糖尿病也有一定的辅助治疗作用。";

                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}植株");
                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}的生长环境");
                    self.InfoStru.PicInfo.Add("绿豆粥");
                    break;
                case 15:
                    self.InfoStru.Name = "食盐";
                    self.InfoStru.Info = "味咸，性寒，归胃、肾、大小肠经，有杀虫止痒、解毒、软坚的作用。食盐有很多种。李时珍说：海盐、井盐、碱盐由人工生产；池盐、崖盐为自然生成。";

                    self.InfoStru.PicInfo.Add("海盐");
                    self.InfoStru.PicInfo.Add("海盐盐场");
                    self.InfoStru.PicInfo.Add("盐焗干果");
                    break;
                case 16:
                    self.InfoStru.Name = "羊肉";
                    self.InfoStru.Info = "味甘，性热，归脾、胃、肾经，有温中暖肾、益气补虚的作用。经常食用可缓解脾胃虚寒所致的反胃、消化不良，对肾虚腰膝酸软、疲劳乏力有一定的食疗作用。";

                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}");
                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}的来源");
                    self.InfoStru.PicInfo.Add("烤羊肉串");
                    break;
                case 17:
                    self.InfoStru.Name = "南瓜";
                    self.InfoStru.Info = "味甘，性平，归脾、胃经，具有补中益气、解毒消肿的功效，适用于脾胃虚弱、营养不良等。南瓜能助消化，常食南瓜可以促进身体生长发育。";

                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}植株");
                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}的生长环境");
                    self.InfoStru.PicInfo.Add("南瓜粥");
                    break;
                case 18:
                    self.InfoStru.Name = "茄子";
                    self.InfoStru.Info = "味甘，性凉，归脾、胃、大肠经，有清热、活血、消肿、降低胆固醇的作用，可预防心脑血管疾病的发生。夏天食用茄子有助于清热解暑，对容易长痱子的人尤为适宜。";

                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}植株");
                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}的生长环境");
                    self.InfoStru.PicInfo.Add("烧茄子");
                    break;
                case 19:
                    self.InfoStru.Name = "木耳";
                    self.InfoStru.Info = "味甘，性平，归肺、肾经，具有凉血止血、健脾开胃之功效。食用木耳能够促进胃肠蠕动，预防便秘，将体内有毒和有害物质及时清除，对肥胖、心脑血管疾病也有一定的预防作用。";

                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}的生长环境");
                    self.InfoStru.PicInfo.Add($"干{self.InfoStru.Name}");
                    self.InfoStru.PicInfo.Add("木耳肉片");
                    break;
                case 20:
                    self.InfoStru.Name = "高粱";
                    self.InfoStru.Info = "味甘、性温，归脾、胃经，具有健脾止泻、利小便的作用，对于缓解慢性腹泻效果较好。小儿消化不良时，可以用高粱米粥进行辅助治疗。";

                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}植株");
                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}的生长环境");
                    self.InfoStru.PicInfo.Add("高粱酿酒");
                    break;
                case 21:
                    self.InfoStru.Name = "黑豆";
                    self.InfoStru.Info = "味甘，性平，归脾、胃经，具有补肾乌发、补血的作用。经常食用，对肾虚体弱、身面浮肿、腰膝酸软等病症有很好的预防和辅助治疗作用。此外，黑豆还有较好的抗衰老作用，有助于减少皮肤皱纹、祛除色斑。";

                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}植株");
                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}的生长环境");
                    self.InfoStru.PicInfo.Add("黑豆熬粥");
                    break;
                case 22:
                    self.InfoStru.Name = "鸡";
                    self.InfoStru.Info = "鸡肉，味甘，性温，归脾、胃经，有温中、益气、补虚的作用，常喝鸡汤可以提高免疫力。\r\n\u3000\u3000鸡肝，有补肝、养血、明目的作用，适合视力下降、贫血者食用。\r\n\u3000\u3000鸡内金，即鸡的砂囊内膜，有健胃消食的作用，可用于治疗小儿积食。";

                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}");
                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}肉");
                    self.InfoStru.PicInfo.Add("红烧鸡块");
                    break;
                case 23:
                    self.InfoStru.Name = "大白菜";
                    self.InfoStru.Info = "味甘，性平，归胃、大肠经，能促进肠蠕动，帮助消化，既能缓解便秘，又有助于营养的吸收，对口腔溃疡、咽喉发炎也有一定的食疗作用。";

                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}");
                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}的生长环境");
                    self.InfoStru.PicInfo.Add("醋溜白菜");
                    break;
                case 24:
                    self.InfoStru.Name = "紫苏叶";
                    self.InfoStru.Info = "味辛，性温，归肺、脾、胃经，有散寒解表、解鱼蟹毒等作用，适用于风寒感冒、恶心呕吐、腹痛吐泻以及食用鱼蟹中毒的病症。";

                    self.InfoStru.PicInfo.Add($"紫苏植株");
                    self.InfoStru.PicInfo.Add($"紫苏的生长环境");
                    self.InfoStru.PicInfo.Add("紫苏入菜");
                    break;
                case 25:
                    self.InfoStru.Name = "苦瓜";
                    self.InfoStru.Info = "味苦，性寒，归心、脾、肺经，有清暑除烦、明目解毒的作用，适用于中暑烦躁、目赤疼痛等病症。现代研究表明，苦瓜有良好的降糖作用，是糖尿病患者理想的食品；苦瓜还有一定的调节血脂、提高免疫力的作用。";

                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}植株");
                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}的生长环境");
                    self.InfoStru.PicInfo.Add("凉拌苦瓜");
                    break;
                case 26:
                    self.InfoStru.Name = "蘑菇";
                    self.InfoStru.Info = "味甘，性凉，归肺、胃、大肠经，具有补脾益气、开胃化食的作用，适用于脾胃虚弱、食欲减退、少气乏力等病症。现代研究表明，蘑菇具有一定的降糖、降压作用，还能提高免疫力。";

                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}植株");
                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}的生长环境");
                    self.InfoStru.PicInfo.Add("蘑菇入菜");
                    break;
                case 27:
                    self.InfoStru.Name = "大米";
                    self.InfoStru.Info = "味甘，性平，归脾、胃经，具有补中益气、健脾养胃的作用。粳米粥营养丰富，容易消化，是配合药疗的调养佳品。经常食用粳米粥，是最简便的食养之法。《随息居饮食谱》中说：“病人、产妇，粥养最宜。”";

                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}植株");
                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}的生长环境");
                    self.InfoStru.PicInfo.Add("大米粥");
                    break;
                case 28:
                    self.InfoStru.Name = "黄牛";
                    self.InfoStru.Info = "黄牛肉，味甘，性温，归脾、胃经，有补脾胃、益气血、强筋骨的作用，对于脾胃虚弱、气血不足等病症有很好的食疗作用。慢性腹泻、脱肛和面浮脚肿者常用黄牛肉炖汤喝，可收到补中益气和消水肿的效果。";

                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}肉");
                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}肉的来源");
                    self.InfoStru.PicInfo.Add("牛排");
                    break;
                case 29:
                    self.InfoStru.Name = "藿香";
                    self.InfoStru.Info = "又称为大叶薄荷、猫尾巴香，味辛，性温，归肺、脾、胃经，有祛暑解表、化湿和胃的作用，可治疗夏季感冒、寒热头疼、呕吐泄泻、鼻塞、手足癣等病症。现代研究表明，藿香具有抗菌、抗病毒作用。以藿香为主要成分的中成药“藿香正气水”是居家常备药品。";

                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}植株");
                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}的生长环境");
                    self.InfoStru.PicInfo.Add("藿香入菜");
                    break;
                case 30:
                    self.InfoStru.Name = "西红柿";
                    self.InfoStru.Info = "又名番茄，味酸、甘，性微寒，归胃、肝经，有生津止渴、健胃消食、清热解毒、凉血平肝的作用，适用于口渴、食欲不振等病症，对高血压、眼底出血有一定的预防作用。";

                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}植株");
                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}的生长环境");
                    self.InfoStru.PicInfo.Add("西红柿入菜");
                    break;
                case 31:
                    self.InfoStru.Name = "鱼腥草";
                    self.InfoStru.Info = "又叫折耳菜，味辛，性微寒，归肺、膀胱、大肠经，有清热解毒、排脓消肿、利尿的作用，适用于肺痈（肺脓疡）咳嗽，痰带脓血、腥臭，尿路感染，尿频涩痛等病症。";

                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}植株");
                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}的生长环境");
                    self.InfoStru.PicInfo.Add("凉拌折耳根");
                    break;
                case 32:
                    self.InfoStru.Name = "洋葱";
                    self.InfoStru.Info = "味辛、甘，性温，归胃经，健胃理气、杀虫、降血脂、预防感冒以及抑菌防腐。";

                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}植株");
                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}的生长环境");
                    self.InfoStru.PicInfo.Add("洋葱炒鸡蛋");
                    break;
                case 33:
                    self.InfoStru.Name = "荔枝";
                    self.InfoStru.Info = "味甘、酸，性温，归肝、脾经，具有养血健脾、行气消肿的作用，适用于脾胃亏虚所致的饮食减少、久泻不止、头目昏花等病症。贫血、体质虚弱的人可以适当多吃些荔枝。";

                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}");
                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}的生长环境");
                    self.InfoStru.PicInfo.Add("南国四大果品之一");
                    break;
                case 34:
                    self.InfoStru.Name = "大麦";
                    self.InfoStru.Info = "味甘，性凉，归脾、肾经，具有健脾和胃、消积清热、利水的作用，对于腹胀、食滞泄泻、小便不利有着很好的缓解作用。";

                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}的生长环境");
                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}磨成面粉");
                    self.InfoStru.PicInfo.Add("蒸馒头");
                    break;
                case 35:
                    self.InfoStru.Name = "黑鱼";
                    self.InfoStru.Info = "又叫鳢鱼、乌鱼，味甘，性凉，归脾、胃、肺、肾经，能补益脾胃、利水消肿，可治疗身面浮肿、妊娠水肿等病症。病后、产后、手术后食用，有助于康复。";

                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}");
                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}片");
                    self.InfoStru.PicInfo.Add("水煮鱼");
                    break;
                case 36:
                    self.InfoStru.Name = "芫荽";
                    self.InfoStru.Info = "又叫香菜、胡荽，味辛，性温，归肺、脾、肝经，具有发汗、消食开胃、止痛解毒的作用，适用于食积、感冒、消化不良等病症。食用芫荽有助于增进食欲，促进胃肠蠕动，提高消化能力。";

                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}的生长环境");
                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}佐料");
                    self.InfoStru.PicInfo.Add("凉拌调料");
                    break;
                case 37:
                    self.InfoStru.Name = "蚌";
                    self.InfoStru.Info = "蚌肉，味甘、咸，性寒，归肝、肾经，具有解酒毒、清肝热、滋阴明目的功效，可治疗眼睛红肿、视物不明等病症。蚌粉，由蚌壳研末而成，味咸，性寒，归肺、肝、胃经，有解热燥湿、化痰止呕、消积的作用，内服可治疗痰饮咳嗽、胃痛、呕逆、带下，外用可治疗痈肿、湿疮。";

                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}");
                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}的来源");
                    self.InfoStru.PicInfo.Add("蚌肉菜肴");
                    break;
                case 38:
                    self.InfoStru.Name = "胡萝卜";
                    self.InfoStru.Info = "味甘，性平，归肺、脾经，健脾化滞、润肠通便，对食欲不振、消化不良、夜盲症等有一定的辅助治疗作用。多吃胡萝卜，可以保护视力，防止视力减退，且有助于降脂降糖，还能预防贫血症的发生。";

                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}植株");
                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}的生长环境");
                    self.InfoStru.PicInfo.Add("胡萝卜入汤");
                    break;
                case 39:
                    self.InfoStru.Name = "香菇";
                    self.InfoStru.Info = "味甘，性平，归脾、胃经，具有补脾益气、开胃消食、降血脂的作用，适于脾胃虚弱、食欲减退、肢软乏力、高血脂等病症。";

                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}");
                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}的生长环境");
                    self.InfoStru.PicInfo.Add("香菇入菜");
                    break;
                case 40:
                    self.InfoStru.Name = "八角茴香";
                    self.InfoStru.Info = "又称为大茴香、八角，味辛，性温，归肝、肾、脾、胃经，有散寒、理气、止痛的作用，可缓解和治疗胃寒呕吐、腹部疼痛等病症。";

                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}");
                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}的生长环境");
                    self.InfoStru.PicInfo.Add("香料中的八角茴香");
                    break;
                case 41:
                    self.InfoStru.Name = "樱桃";
                    self.InfoStru.Info = "又名含桃、荆桃、朱樱，味甘，性温，归脾、肾经，有补脾益肾的作用，可缓解脾虚泄泻、腰腿疼痛。另外，吃樱桃可以滋润皮肤、养颜美容。";

                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}植株");
                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}的生长环境");
                    self.InfoStru.PicInfo.Add("生命之果");
                    break;
                case 42:
                    self.InfoStru.Name = "青稞";
                    self.InfoStru.Info = "味咸，性平、凉，归脾、胃经，具有益气、除湿、止泻、降血脂、降低胆固醇的作用，对防治心脑血管疾病有一定的帮助。我国西北、西南等地均有栽培；西藏地区的种植面积较大，青稞在当地粮食作物中占有很大比重。";

                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}植株");
                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}的生长环境");
                    self.InfoStru.PicInfo.Add("杂粮饭");
                    break;
                case 43:
                    self.InfoStru.Name = "黑米";
                    self.InfoStru.Info = "味甘，性平，归脾、胃经，具有健脾开胃、滋阴补肾、清肝明目的作用，对头晕目眩、贫血、白发、眼疾等拥有很好的食疗功效。黑米是稻米中的珍贵品种，是药食兼用的良品，被称为“长寿米”；因为在古代被列为贡品，所以又被称为“贡米”。";

                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}");
                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}的生长环境");
                    self.InfoStru.PicInfo.Add("黑米饭");
                    break;
                case 44:
                    self.InfoStru.Name = "螃蟹";
                    self.InfoStru.Info = "味咸，性寒，归肝经，有清热散结、壮筋骨的作用，可以用于治疗跌打损伤、烫火伤等。螃蟹不但味道独特，而且营养丰富，是一种高蛋白补品。";

                    self.InfoStru.PicInfo.Add($"海蟹");
                    self.InfoStru.PicInfo.Add($"河蟹");
                    self.InfoStru.PicInfo.Add("清蒸螃蟹");
                    break;
                case 45:
                    self.InfoStru.Name = "马齿苋";
                    self.InfoStru.Info = "味甘、微苦，性微寒，归心、肺经，有养阴润肺、清心安神的作用，适用于虚烦惊悸、热病后余热未消、失眠多梦、精神恍惚等，以及肺燥或肺热咳嗽的辅助治疗，且有益于降糖、养颜。";

                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}");
                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}的生长环境");
                    self.InfoStru.PicInfo.Add("凉拌马齿苋");
                    break;
                case 46:
                    self.InfoStru.Name = "百合";
                    self.InfoStru.Info = "味甘、微苦，性微寒，归心、肺经，有养阴润肺、清心安神的作用，适用于虚烦惊悸、热病后余热未消、失眠多梦、精神恍惚等，以及肺燥或肺热咳嗽的辅助治疗，且有益于降糖、养颜。";

                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}");
                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}植株");
                    self.InfoStru.PicInfo.Add("百合入粥");
                    break;
                case 47:
                    self.InfoStru.Name = "茶树菇";
                    self.InfoStru.Info = "味甘，性平，归脾、肾经，有益肠胃、化痰理气、润燥止咳等作用，能健脾开胃，平肝清热，明目美容，抗衰老，提高人体免疫力。";

                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}");
                    self.InfoStru.PicInfo.Add($"干{self.InfoStru.Name}");
                    self.InfoStru.PicInfo.Add("茶树菇入汤");
                    break;
                case 48:
                    self.InfoStru.Name = "辣椒";
                    self.InfoStru.Info = "味辛，性热，归心、脾经，具有温中散寒、开胃消食、活血通络的作用，适用于呕吐泻痢、冻疮肿痛等。可改善受寒引起的胃口不好、腹胀腹痛，能促进胃肠蠕动，排除消化道中积存的气体。因辣椒具有较强的刺激性，容易引起咳嗽、便秘，多食极易造成上腹部不适、腹泻等，故患有口腔疾患、咽炎、胃溃疡、便秘、痔疮者均不宜食用。";

                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}植株");
                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}的生长环境");
                    self.InfoStru.PicInfo.Add("辣椒面");
                    break;
                case 49:
                    self.InfoStru.Name = "枇杷";
                    self.InfoStru.Info = "味甘、酸，性凉，归肺、脾经，具有润肺止咳、下气止渴等作用，经常用于肺燥咳嗽、暑热声音嘶哑、呕吐呃逆等病症的辅助治疗。枇杷制成的糖水罐头、果膏、果露有一定的润肺、清热作用。枇杷叶是中医常用的止咳药，如川贝枇杷膏中就含有枇杷叶的成分。";

                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}植株");
                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}的生长环境");
                    self.InfoStru.PicInfo.Add("枇杷汤剂");
                    break;
                case 50:
                    self.InfoStru.Name = "荞麦";
                    self.InfoStru.Info = "荞麦味甘、微酸，性寒，归脾、胃、大肠经，有健脾消积、降气等作用。荞麦有降血糖的作用，是糖尿病患者较理想的食品。荞麦还是很好的大肠“清道夫”，能够刺激肠蠕动，促进排便。";

                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}");
                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}的生长环境");
                    self.InfoStru.PicInfo.Add("荞麦面");
                    break;
                case 51:
                    self.InfoStru.Name = "海带";
                    self.InfoStru.Info = "中药名称为昆布，味咸，性寒，归肝、胃、肾经，有清热、利水、消肿的作用，可缓解水肿等病症。现代研究发现，海带可以降压、降脂、降糖，特别适合“三高”人群食用。";

                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}");
                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}的采集");
                    self.InfoStru.PicInfo.Add("海带入汤");
                    break;
                case 52:
                    self.InfoStru.Name = "白茅根";
                    self.InfoStru.Info = "味甘，性寒，归心、肺、胃、膀胱经，有清热生津、凉血止血、利尿的作用，可用于肺热喘咳、胃热呕吐、血热出血、小便淋沥涩痛、水肿等病症的辅助治疗。";

                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}");
                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}的生长环境");
                    self.InfoStru.PicInfo.Add("白茅根饮品");
                    break;
                case 53:
                    self.InfoStru.Name = "西瓜";
                    self.InfoStru.Info = "又名寒瓜，味甘，性寒，归心、胃、膀胱经，有清热利尿、解暑生津的作用，可用于热病烦渴、口舌生疮等病症的辅助治疗。西瓜瓤及西瓜皮营养丰富，可有效补充人体所需要的各种营养成分，但肾功能不全者不能多食，以防大量水分留在体内，加重肾脏负担。";

                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}植株");
                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}的生长环境");
                    self.InfoStru.PicInfo.Add("西瓜汁");
                    break;
                case 54:
                    self.InfoStru.Name = "大枣";
                    self.InfoStru.Info = "又名美枣、良枣，味甘，性平，归脾、胃经，有补脾胃、益气血、安心神的作用，可用于气血虚弱所致的面色苍白、四肢乏力等病症的辅助治疗。";

                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}植株");
                    self.InfoStru.PicInfo.Add($"干{self.InfoStru.Name}");
                    self.InfoStru.PicInfo.Add("山药大枣粥");
                    break;
                case 55:
                    self.InfoStru.Name = "玫瑰";
                    self.InfoStru.Info = "玫瑰的花：味甘、苦，性温，归肝、脾经，有理气解郁、和血调经的作用，适用于月经不调、泄泻、跌打损伤等病症的调理。玫瑰花在使用过程中除可以煎汤服用外，还可以泡水代茶饮。";

                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}的生长环境");
                    self.InfoStru.PicInfo.Add($"干{self.InfoStru.Name}花蕾");
                    self.InfoStru.PicInfo.Add("玫瑰饼");
                    break;
                case 56:
                    self.InfoStru.Name = "榛子";
                    self.InfoStru.Info = "味甘，性平，归脾、胃经，具有健脾和胃、润肺止咳的作用，用于缓解脾虚泄泻、食欲不振、咳嗽等病症的辅助治疗，还可用于疾病初愈后的体力恢复。";

                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}");
                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}的生长环境");
                    self.InfoStru.PicInfo.Add("榛子入菜");
                    break;
                case 57:
                    self.InfoStru.Name = "豇豆";
                    self.InfoStru.Info = "又叫豆角，味甘、咸，性平，归脾、肾经，有健脾、利湿、补肾的作用，可用于脾胃虚弱、腹泻痢疾、小便频数等病症的辅助治疗。";

                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}");
                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}的生长环境");
                    self.InfoStru.PicInfo.Add("干煸豇豆");
                    break;
                case 58:
                    self.InfoStru.Name = "莴苣";
                    self.InfoStru.Info = "又名千金菜，味苦、甘，性凉，归胃、小肠经，有清热解毒、利尿的作用，可以促进消化，帮助排便。";

                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}");
                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}的生长环境");
                    self.InfoStru.PicInfo.Add("莴苣入菜");
                    break;
                case 59:
                    self.InfoStru.Name = "蜂蜜";
                    self.InfoStru.Info = "味甘，性平，归肺、脾、大肠经，有补中、润燥、止痛、解毒的作用，可缓解干燥性咳嗽、老年性便秘。";

                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}");
                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}的来源");
                    self.InfoStru.PicInfo.Add("采集蜂蜜");
                    break;
                case 60:
                    self.InfoStru.Name = "猕猴桃";
                    //self.InfoStru.Info = "味酸、甘，性寒，归胃、肝、肾经，有生津润燥、止渴的作用，可用于消化不良、痔疮等病症的辅助治疗。";
                    self.InfoStru.Info = "味酸、甘，性寒，归胃、肝、肾经，有健胃、解热的作用，可用于消化不良、痔疮等病症的辅助治疗。";

                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}");
                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}的生长环境");
                    self.InfoStru.PicInfo.Add("维C之王");
                    break;
                case 61:
                    self.InfoStru.Name = "甜瓜";
                    self.InfoStru.Info = "又名甘瓜，味甘，性寒，归心、胃经，有消暑热、解烦渴、利小便的作用，可用于暑热烦渴、小便不利等病症的辅助治疗。";

                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}植株");
                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}的生长环境");
                    self.InfoStru.PicInfo.Add("夏季解暑佳品");
                    break;
                case 62:
                    self.InfoStru.Name = "柑";
                    self.InfoStru.Info = "又名金实，味甘、酸，性凉，归肺、肝经，有生津止渴、醒酒利尿的作用，可用于口干、醉酒等病症的辅助治疗。";

                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}的植株");
                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}的生长环境");
                    self.InfoStru.PicInfo.Add("酸甜可口");
                    break;
                case 63:
                    self.InfoStru.Name = "赤小豆";
                    self.InfoStru.Info = "又名红小豆、赤豆，味甘、酸，性平，归心、小肠经，有利水消肿、清热解毒、排脓的作用，可用于水肿、痈肿疮毒等病症的辅助治疗。";

                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}");
                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}的生长环境");
                    self.InfoStru.PicInfo.Add("赤小豆入粥");
                    break;
                case 64:
                    self.InfoStru.Name = "香椿";
                    self.InfoStru.Info = "名味甘，性平，归肺、胃、大肠经，有健脾开胃的作用，适合食欲不佳者食用。香椿是早春美食之一，它香气浓郁，可拌成小菜佐餐。";

                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}");
                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}的生长环境");
                    self.InfoStru.PicInfo.Add("香椿蛋饼");
                    break;
                case 65:
                    self.InfoStru.Name = "马铃薯";
                    self.InfoStru.Info = "味甘，性平，归胃、大肠经，有益气健脾的作用，可预防便秘与其他肠道疾病的发生。";

                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}");
                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}的生长环境");
                    self.InfoStru.PicInfo.Add("马铃薯入菜");
                    break;
                case 66:
                    self.InfoStru.Name = "梨";
                    self.InfoStru.Info = "味甘、微酸，性凉，归肺、胃经，有清热生津、润燥化痰的作用，可用于热咳或者燥咳等病症的辅助治疗。常食梨，能缓解咽喉干疼、便秘尿赤等不适。";

                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}");
                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}的生长环境");
                    self.InfoStru.PicInfo.Add("雪梨饮品");
                    break;
                case 67:
                    self.InfoStru.Name = "桂花";
                    self.InfoStru.Info = "又称木樨，味辛，性温，归肺、脾、肾经，有散寒止痛的作用，可用于肚腹冷痛、牙痛口臭等病症的辅助治疗。";

                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}");
                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}的生长环境");
                    self.InfoStru.PicInfo.Add("桂花饮品");
                    break;
                case 68:
                    self.InfoStru.Name = "山奈";
                    self.InfoStru.Info = "味辛，性温，归脾、胃经，有消食、止痛的作用，可用于食积和牙疼等病症的辅助治疗。";

                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}");
                    self.InfoStru.PicInfo.Add($"干{self.InfoStru.Name}");
                    self.InfoStru.PicInfo.Add("山奈炒肉");
                    break;
                case 69:
                    self.InfoStru.Name = "韭菜";
                    self.InfoStru.Info = "味辛，性温，归肾、肺、胃、肝经，有行气、解毒、散瘀的作用，用于噎膈反胃、肿毒、跌打损伤等病症的辅助治疗。";

                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}");
                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}的生长环境");
                    self.InfoStru.PicInfo.Add("韭菜炒鸡蛋");
                    break;
                case 70:
                    self.InfoStru.Name = "毛笋";
                    self.InfoStru.Info = "味甘，性寒，归肺、胃经，有化痰、消胀的作用，可用于食积、腹胀等病症的辅助治疗。食用毛笋，能促进胃肠蠕动，预防便秘。";

                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}");
                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}的生长环境");
                    self.InfoStru.PicInfo.Add("毛笋炖肉");
                    break;
                case 71:
                    self.InfoStru.Name = "芋头";
                    self.InfoStru.Info = "味甘、辛，性平，归胃经，有健脾补虚等功效，可用于脾胃虚弱、纳少乏力、烫火伤等病症的辅助治疗。";

                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}");
                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}的生长环境");
                    self.InfoStru.PicInfo.Add("芋头煲肉");
                    break;
                case 72:
                    self.InfoStru.Name = "花椒";
                    self.InfoStru.Info = "味辛，性温，归脾、胃、肾经，有温中止痛、杀虫止痒的作用，可缓解外寒内侵所致的胃寒腹痛、呕吐、皮肤瘙痒等病症。";

                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}");
                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}的生长环境");
                    self.InfoStru.PicInfo.Add("麻辣火锅");
                    break;
                case 73:
                    self.InfoStru.Name = "无花果";
                    self.InfoStru.Info = "味甘，性凉，归肺、胃、大肠经，有清热生津、健脾开胃等作用，用于咽喉肿痛、食欲不振、消化不良等病症的辅助治疗。";

                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}");
                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}的生长环境");
                    self.InfoStru.PicInfo.Add("无花果果脯");
                    break;
                case 74:
                    self.InfoStru.Name = "李子";
                    self.InfoStru.Info = "又称为李实，味甘、酸，性平，归肝、脾、胃经，有清热、生津、消积的作用，可用于结核病低热、糖尿病口渴、消化不良等病症的辅助治疗。但脾胃虚弱者要少吃或者不吃。";

                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}");
                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}的生长环境");
                    self.InfoStru.PicInfo.Add("干李子");
                    break;
                case 75:
                    self.InfoStru.Name = "豆腐";
                    self.InfoStru.Info = "味甘，性凉，归脾、胃、大肠经，有清热解毒、生津润燥、健脾益气等作用，可用于痤疮粉刺、口干咽燥、病后体虚食少等病症的辅助治疗。";

                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}");
                    self.InfoStru.PicInfo.Add($"凉拌卤{self.InfoStru.Name}干");
                    self.InfoStru.PicInfo.Add("麻婆豆腐");
                    break;
                case 76:
                    self.InfoStru.Name = "丝瓜";
                    self.InfoStru.Info = "味甘，性凉，归肺、肝、胃、大肠经，有清热化痰、凉血解毒的作用，可用于咳嗽痰喘、痔疮出血等病症的辅助治疗。";

                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}");
                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}的生长环境");
                    self.InfoStru.PicInfo.Add("炒丝瓜");
                    break;
                case 77:
                    self.InfoStru.Name = "小茴香";
                    self.InfoStru.Info = "味辛，性温，归肝、肾、膀胱、胃经，有散寒止痛、理气和胃的作用，用于受寒引起的胃胀、胃痛、腹痛等病症的辅助治疗。";

                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}");
                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}的生长环境");
                    self.InfoStru.PicInfo.Add("小茴香入汤");
                    break;
                case 78:
                    self.InfoStru.Name = "番木瓜";
                    self.InfoStru.Info = "味甘，性平，归胃、脾经，有消食、除湿通络的作用，可用于消化不良、肢体麻木等病症的辅助治疗。";

                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}");
                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}的生长环境");
                    self.InfoStru.PicInfo.Add("乳瓜");
                    break;
                case 79:
                    self.InfoStru.Name = "花生";
                    self.InfoStru.Info = "味甘，性平，归肺、脾经，具有健脾养胃、润肺化痰的作用，可用于反胃不舒、肺燥咳嗽等病症的辅助治疗。";

                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}");
                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}的生长环境");
                    self.InfoStru.PicInfo.Add("炒花生");
                    break;
                case 80:
                    self.InfoStru.Name = "仙人掌";
                    self.InfoStru.Info = "味苦，性寒，归胃、肺、大肠经，有行气活血、凉血止血、解毒消肿的作用，可用于胃痛、喉痛、便血等病症的辅助治疗。";

                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}");
                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}的生长环境");
                    self.InfoStru.PicInfo.Add("凉拌仙人掌");
                    break;
                case 81:
                    self.InfoStru.Name = "蔷薇花";
                    self.InfoStru.Info = "味苦，性凉，归胃、肝经，具有清热解毒、调和脾胃的作用，可用于暑热烦渴、口疮、肚腹胀满等病症的辅助治疗。";

                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}");
                    self.InfoStru.PicInfo.Add($"蔷薇的生长环境");
                    self.InfoStru.PicInfo.Add("蔷薇花泡茶");
                    break;
                case 82:
                    self.InfoStru.Name = "椰子";
                    self.InfoStru.Info = "味甘、辛，性平，归脾、肾经，有补脾益肾的作用，可用于脾虚水肿、腰膝酸软等病症的辅助治疗。";

                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}");
                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}的生长环境");
                    self.InfoStru.PicInfo.Add("椰奶冻");
                    break;
                case 83:
                    self.InfoStru.Name = "鲤鱼";
                    self.InfoStru.Info = "味甘，性平，归脾、肾、胃、胆经，有健脾和胃、利水的作用，可用于胃痛、小便不利等病症的辅助治疗。";

                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}");
                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}的生长环境");
                    self.InfoStru.PicInfo.Add("红烧鲤鱼");
                    break;
                case 84:
                    self.InfoStru.Name = "苋菜";
                    self.InfoStru.Info = "味甘，性微寒，归大肠、小肠经，具有清热解毒、通利二便的作用，可用于湿热泄泻、大便秘结等病症的辅助治疗。";

                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}");
                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}的生长环境");
                    self.InfoStru.PicInfo.Add("炒苋菜");
                    break;
                case 85:
                    self.InfoStru.Name = "紫菜";
                    self.InfoStru.Info = "味甘、咸，性寒，归肺、脾、膀胱经，有化痰利咽、利水除湿的作用，可以缓解咽喉肿痛、咳嗽等病症。";

                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}");
                    self.InfoStru.PicInfo.Add($"寿司");
                    self.InfoStru.PicInfo.Add("紫菜入汤");
                    break;
                case 86:
                    self.InfoStru.Name = "冬瓜";
                    self.InfoStru.Info = "味甘、淡，性微寒，归于肺、大肠、小肠、膀胱经，具有化痰生津、利湿消肿的作用，用于水肿胀满、小便不利等病症的辅助治疗。冬瓜清热生津，尤其适合夏日食用。";

                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}");
                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}的生长环境");
                    self.InfoStru.PicInfo.Add("冬瓜入汤");
                    break;
                case 87:
                    self.InfoStru.Name = "胡椒";
                    self.InfoStru.Info = "味辛，性热，归胃、大肠经，有温中散寒、下气的作用，可用于胃脘冷痛、癫痫等病症的辅助治疗。";

                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}");
                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}的生长环境");
                    self.InfoStru.PicInfo.Add("胡椒粉");
                    break;
                case 88:
                    self.InfoStru.Name = "橄榄";
                    self.InfoStru.Info = "又名青果，味甘、酸，性平，归肺、胃经，有清肺利咽、生津止渴的作用，可用于咳嗽痰血、咽喉肿痛等病症的辅助治疗。";

                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}");
                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}的生长环境");
                    self.InfoStru.PicInfo.Add("橄榄榨油");
                    break;
                case 89:
                    self.InfoStru.Name = "葡萄";
                    self.InfoStru.Info = "味甘、酸，性平，归肺、脾、肾经，有补气血、强筋骨、利小便的作用，可用于气血虚弱、心悸盗汗、风湿痹痛、水肿等病症的辅助治疗。";

                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}");
                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}的生长环境");
                    self.InfoStru.PicInfo.Add("葡萄酿酒");
                    break;
                case 90:
                    self.InfoStru.Name = "莲藕";
                    self.InfoStru.Info = "归心、肝、脾、胃经。生莲藕味甘，性寒，有凉血止血、除热清胃等作用，可用于口鼻出血、醉酒等病症的辅助治疗；熟者味甘，性温，有健脾开胃等作用，可用于不思饮食等病症的辅助治疗。";

                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}");
                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}的生长环境");
                    self.InfoStru.PicInfo.Add("糯米莲藕");
                    break;
                case 91:
                    self.InfoStru.Name = "茭白";
                    self.InfoStru.Info = "味甘，性寒，归肝、脾、肺经，有解热毒、利二便的作用，可用于痢疾、二便不通等病症的辅助治疗。";

                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}");
                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}的生长环境");
                    self.InfoStru.PicInfo.Add("茭白炒肉丝");
                    break;
                case 92:
                    self.InfoStru.Name = "红薯";
                    self.InfoStru.Info = "味甘，性平，归脾、肾经，具有补气生津、宽肠通便的作用。经常食用红薯，可预防多种老年性疾病，还能促进肠道蠕动，润肠通便。";

                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}");
                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}的生长环境");
                    self.InfoStru.PicInfo.Add("蒸红薯");
                    break;
                case 93:
                    self.InfoStru.Name = "苹果";
                    self.InfoStru.Info = "味甘、酸，性凉，归脾、大肠经，有生津除烦、健胃醒酒的作用，用于咽干口渴、脾虚泄泻、食后腹胀等病症的辅助治疗。";

                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}");
                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}的生长环境");
                    self.InfoStru.PicInfo.Add("苹果饮品");
                    break;
                case 94:
                    self.InfoStru.Name = "柚子";
                    self.InfoStru.Info = "味甘、酸，性寒，归胃、肺经，有开胃消食、化痰止咳、生津止渴的作用，可用于消化不良、痰多咳喘、酒后烦渴等病症的辅助治疗。";

                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}");
                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}的生长环境");
                    self.InfoStru.PicInfo.Add("最具食疗效果的水果");
                    break;
                case 95:
                    self.InfoStru.Name = "沙棘";
                    self.InfoStru.Info = "味酸、涩，性温，归肺、肝、胃经，有止咳化痰、健胃消食的作用，可用于咳嗽痰多、消化不良等病症的辅助治疗。";

                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}");
                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}的生长环境");
                    self.InfoStru.PicInfo.Add("沙棘饮品");
                    break;
                case 96:
                    self.InfoStru.Name = "桃子";
                    self.InfoStru.Info = "味甘、酸，性温，归肺、大肠经，有生津润肠、活血消积的作用，可用于便秘、口渴少津、闭经等病症的辅助治疗。";

                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}");
                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}的生长环境");
                    self.InfoStru.PicInfo.Add("桃罐头");
                    break;
                case 97:
                    self.InfoStru.Name = "金橘";
                    self.InfoStru.Info = "味甘、辛，性温，归肝、脾、胃经，有理气解郁、消食化痰、醒酒的作用，可用于胸闷郁结、食滞纳呆、咳嗽痰多、伤酒口渴等病症的辅助治疗。";

                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}");
                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}的生长环境");
                    self.InfoStru.PicInfo.Add("金橘泡水");
                    break;
                case 98:
                    self.InfoStru.Name = "腐乳";
                    self.InfoStru.Info = "味咸、甘，性平，归脾、胃经，有益胃和中的作用，可用于腹胀、泄泻等病症的辅助治疗。";

                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}");
                    self.InfoStru.PicInfo.Add($"红油{self.InfoStru.Name}");
                    self.InfoStru.PicInfo.Add("各种口味的腐乳");
                    break;
                case 99:
                    self.InfoStru.Name = "荷叶";
                    self.InfoStru.Info = "味苦，性平，归心、肝、脾经，有清热解暑的作用，可用于由暑热引起的烦渴、泄泻等病症的辅助治疗。";

                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}");
                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}入药");
                    self.InfoStru.PicInfo.Add("荷叶代茶饮");
                    break;
                case 100:
                    self.InfoStru.Name = "神曲";
                    self.InfoStru.Info = "味甘、辛，性温，归脾、胃经，有消食化积、健脾和胃的作用，可用于饮食停滞、食欲不振等病症的辅助治疗。";

                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}");
                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}代茶饮");
                    self.InfoStru.PicInfo.Add("神曲口服液");
                    break;
                case 101:
                    self.InfoStru.Name = "甘蓝";
                    self.InfoStru.Info = "味甘，性平，归肝、胃经，具有清利湿热、散结止痛的作用，可用于湿热黄疸、上腹胀气隐痛等病症的辅助治疗。";

                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}");
                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}的生长环境");
                    self.InfoStru.PicInfo.Add("炒甘蓝");
                    break;
                case 102:
                    self.InfoStru.Name = "葫芦";
                    self.InfoStru.Info = "味甘，性平，归肺、脾、肾经，具有利水、消肿的作用，可用于腹水、水肿等病症的辅助治疗。";

                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}");
                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}的生长环境");
                    self.InfoStru.PicInfo.Add("葫芦制品");
                    break;
                case 103:
                    self.InfoStru.Name = "槐花";
                    self.InfoStru.Info = "味苦，性微寒，归肝、大肠经，有凉血止血的作用，可用于便血、痔疮等病症的辅助治疗。";

                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}");
                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}的生长环境");
                    self.InfoStru.PicInfo.Add("干槐花");
                    break;
                case 104:
                    self.InfoStru.Name = "柿子";
                    self.InfoStru.Info = "味甘，性凉，归心、肺、大肠经，有清热、润肺、生津、解毒的作用，用于热渴、久咳、口疮、便血等病症的辅助治疗。";

                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}");
                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}的生长环境");
                    self.InfoStru.PicInfo.Add("柿饼");
                    break;
                case 105:
                    self.InfoStru.Name = "荸荠";
                    self.InfoStru.Info = "味甘，性寒，归肺、胃经，具有清热生津、明目利咽的作用，可用于目赤口干、咽喉肿痛等病症的辅助治疗。";

                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}");
                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}的生长环境");
                    self.InfoStru.PicInfo.Add("荸荠入汤");
                    break;
                case 106:
                    self.InfoStru.Name = "普洱茶";
                    self.InfoStru.Info = "味甘、苦，性寒，归胃、肝、大肠经，有清热生津、消食解酒、醒神透疹等作用，可用于暑热口渴、头疼目昏、肉食积滞、神疲多眠等病症的辅助治疗。";

                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}");
                    self.InfoStru.PicInfo.Add($"陈年{self.InfoStru.Name}");
                    self.InfoStru.PicInfo.Add("普洱茶汤");
                    break;
                case 107:
                    self.InfoStru.Name = "豌豆";
                    self.InfoStru.Info = "味甘，性平，归脾、胃经，具有和中下气、利水消毒的作用，可用于吐逆、消渴等病症的辅助治疗。";

                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}");
                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}的生长环境");
                    self.InfoStru.PicInfo.Add("鲜豌豆");
                    break;
                case 108:
                    self.InfoStru.Name = "覆盆子";
                    self.InfoStru.Info = "味甘、酸，性温，归肝、肾经，有补肝益肾、明目等作用，可用于尿频遗尿、目视昏暗、须发早白等病症的辅助治疗。";

                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}");
                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}入药");
                    self.InfoStru.PicInfo.Add("覆盆子代茶饮");
                    break;
                case 109:
                    self.InfoStru.Name = "黑大豆";
                    self.InfoStru.Info = "味甘，性平，归脾、肾经，有利水、解毒、益肾的作用，可用于水肿胀满，药物、食物中毒，肾虚腰疼等病症的辅助治疗。";

                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}");
                    self.InfoStru.PicInfo.Add($"黑豆豆浆");
                    self.InfoStru.PicInfo.Add("黑豆入粥");
                    break;
                case 110:
                    self.InfoStru.Name = "冰糖";
                    self.InfoStru.Info = "味甘，性平，归脾、肺经，具有补中和胃、润肺止咳的作用，可用于脾胃气虚、肺燥咳嗽、痰中带血等病症的辅助治疗。";

                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}");
                    self.InfoStru.PicInfo.Add($"{self.InfoStru.Name}银耳汤");
                    self.InfoStru.PicInfo.Add("冰糖果饮");
                    break;
                default:
                    break;
            }
        }

        public static void OnMouseClick(this YinShiYuJianKang_Component self)
        {
            switch (GSMouseData.LastObjectClicked.name)
            {
                case "NextBtn":
                    self.SceneChange.Play("SceneChange", 0, 0);
                    break;
                case "PrevBtn":
                    self.SceneChange.Play("SceneChange1", 0, 0);
                    break;
                case "QuitBtn":
                    break;
                case "IdleItem0":
                    self.InitMotionData();

                    self.DetailMotion.Play("Detail_Motion", 0, 0);
                    break;
                default:
                    Log.Info("点击了不该点击的东西");
                    break;
            }
        }

        public static void InitMotionData(this YinShiYuJianKang_Component self)
        {
            switch (self.FontPicIndex)
            {
                case 0:
                    self.MotionPic[0].overrideSprite = self.DetailPicSprite[0];
                    self.MotionPic[1].overrideSprite = self.DetailPicSprite[1];
                    self.MotionPic[2].overrideSprite = self.DetailPicSprite[2];
                    self.MotionPic[3].overrideSprite = self.DetailPicSprite[0];

                    self.MotionPicGroup.SetActive(true);
                    self.IdlePicGroup.SetActive(false);

                    self.FontPicIndex = 1;
                    self.IdlePic[0].overrideSprite = self.DetailPicSprite[self.FontPicIndex];
                    self.IdlePic[1].overrideSprite = self.DetailPicSprite[self.FontPicIndex + 1];
                    self.IdlePic[2].overrideSprite = self.DetailPicSprite[self.FontPicIndex - 1];

                    self.Title_Inpart2.text = self.InfoStru.PicInfo[1];

                    break;
                case 1:
                    self.MotionPic[0].overrideSprite = self.DetailPicSprite[1];
                    self.MotionPic[1].overrideSprite = self.DetailPicSprite[2];
                    self.MotionPic[2].overrideSprite = self.DetailPicSprite[0];
                    self.MotionPic[3].overrideSprite = self.DetailPicSprite[1];

                    self.MotionPicGroup.SetActive(true);
                    self.IdlePicGroup.SetActive(false);

                    self.FontPicIndex = 2;
                    self.IdlePic[0].overrideSprite = self.DetailPicSprite[self.FontPicIndex];
                    self.IdlePic[1].overrideSprite = self.DetailPicSprite[self.FontPicIndex - 2];
                    self.IdlePic[2].overrideSprite = self.DetailPicSprite[self.FontPicIndex - 1];

                    self.Title_Inpart2.text = self.InfoStru.PicInfo[2];
                    break;
                case 2:
                    self.MotionPic[0].overrideSprite = self.DetailPicSprite[2];
                    self.MotionPic[1].overrideSprite = self.DetailPicSprite[0];
                    self.MotionPic[2].overrideSprite = self.DetailPicSprite[1];
                    self.MotionPic[3].overrideSprite = self.DetailPicSprite[2];

                    self.MotionPicGroup.SetActive(true);
                    self.IdlePicGroup.SetActive(false);

                    self.FontPicIndex = 0;
                    self.IdlePic[0].overrideSprite = self.DetailPicSprite[self.FontPicIndex];
                    self.IdlePic[1].overrideSprite = self.DetailPicSprite[self.FontPicIndex + 1];
                    self.IdlePic[2].overrideSprite = self.DetailPicSprite[self.FontPicIndex + 2];

                    self.Title_Inpart2.text = self.InfoStru.PicInfo[0];
                    break;
                default:
                    //Log.Info("越界了");
                    break;
            }
        }

        public static void BackPart2(this YinShiYuJianKang_Component self)
        {
            self.MotionPic[0].overrideSprite = self.DetailPicSprite[0];
            self.MotionPic[1].overrideSprite = self.DetailPicSprite[1];
            self.MotionPic[2].overrideSprite = self.DetailPicSprite[2];
            self.MotionPic[3].overrideSprite = self.DetailPicSprite[0];

            self.FontPicIndex = 0;
            self.IdlePic[0].overrideSprite = self.DetailPicSprite[self.FontPicIndex];
            self.IdlePic[1].overrideSprite = self.DetailPicSprite[self.FontPicIndex + 1];
            self.IdlePic[2].overrideSprite = self.DetailPicSprite[self.FontPicIndex + 2];

            self.Title_Inpart2.text = self.InfoStru.PicInfo[0];
        }

        public static void OnSingleClickUp(this YinShiYuJianKang_Component self)
        {
            if (GSRunningData.PageIndex == 0)
            {
                self.SceneChange.Play("SceneChange", 0, 0);
                GSRunningData.PageIndex = 1;
            }
        }

        public static void OnSingleClickDown(this YinShiYuJianKang_Component self)
        {
            if (GSRunningData.PageIndex == 1)
            {
                self.SceneChange.Play("SceneChange1", 0, 0);
                GSRunningData.PageIndex = 0;
            }
        }

        public static void OnDoubleClickUp(this YinShiYuJianKang_Component self)
        {
            if (GSRunningData.PageIndex == 1)
            {
                self.InitMotionData();

                self.DetailMotion.Play("Detail_Motion", 0, 0);
            }
        }

        public static void OnDoubleClickDown(this YinShiYuJianKang_Component self)
        {
            self.Quit();
        }

        public static async void Quit(this YinShiYuJianKang_Component self)
        {
            DOTween.KillAll();

            // 必须赋值
            GSRunningData.Target = GSUIType.UILessonScene;
            GSRunningData.Lesson_SelectedIndex = self.BackLessonSelectedIndex;
            GSRunningData.Section_SelectedIndex = 0;
            // 根据类型赋值
            GSRunningData.YinShiYuJianKang_SelectedIndex = 0;
            // 操作清空
            GSRunningData.Limit = false;
            GSRunningData.PageIndex = 0;
            GSRunningData.ChoiceIndex = 0;
            // 流程删除赋值
            GSRunningData.HistTaget.Add(GSUIType.UIYinShiYuJianKangScene, true);           

            await GSUIHelper.Create(self.DomainScene(), GSUIType.UILoadingScene, UILayer.High);


            #region 测试用
            //int jumpIndex = 104;

            //GSRunningData.Target = "YinShiYuJianKang";
            //if (GSRunningData.PageIndex < 2)
            //{
            //    GSRunningData.PageIndex = jumpIndex;
            //}
            //else
            //{
            //    GSRunningData.PageIndex += 1;
            //}            

            //Log.Info("退出时PageIndex为 " + GSRunningData.PageIndex);
            //GSRunningData.ChoiceIndex = 18;
            //GSRunningData.ChoiceIndex += 1;
            #endregion

        }
    }
}
