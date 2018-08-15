using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCObserverStudent
{
    class BlackList
    {
        private Hashtable blacklist;
        public BlackList()
        {
            blacklist = new Hashtable();
            blacklist.Add("Steam", "Steam");
            blacklist.Add("GTA", "GTA");
            blacklist.Add("QQ", "腾讯QQ");
            blacklist.Add("crossfire", "穿越火线");
            blacklist.Add("wow", "魔兽世界");
            blacklist.Add("MIR2", "热血传奇");
            blacklist.Add("cstrike-online", "反恐精英online");
            blacklist.Add("qqfo", "QQ幻想");
            blacklist.Add("DNFchina", "地下城与勇士");
            blacklist.Add("Client", "QQ堂");
            blacklist.Add("QQSG", "QQ三国");
            blacklist.Add("QQxu", "QQ炫舞");
            blacklist.Add("Game", "英雄岛封测版");
            blacklist.Add("GameApp", "QQ飞车");
            blacklist.Add("xypqlayer", "梦幻西游");
            blacklist.Add("palonline", "仙剑OL");
            blacklist.Add("digimon", "数码宝贝OL");
            blacklist.Add("wow-64", "魔兽世界");
            blacklist.Add("zhengtu2", "征途2");
            blacklist.Add("xy3launch", "大话西游3");
            blacklist.Add("audition", "劲舞团");
            blacklist.Add("qqhxsj", "QQ幻想世界");
            blacklist.Add("elementclient", "完美世界/诛仙/武林外传");
            blacklist.Add("JX3Client", "剑侠情缘叁网络版");
            blacklist.Add("TLBBDownload", "天龙八部2");
            blacklist.Add("FF2Client", "FIFA OL2");
            blacklist.Add("crazykart", "疯狂赛车");
            blacklist.Add("my", "梦幻西游");
            blacklist.Add("xy2", "大话西游2");
            blacklist.Add("zhengtu", "绿色征途");
            blacklist.Add("tw2", "天下贰");
            blacklist.Add("ask", "问道");
            blacklist.Add("BubbleFighter", "泡泡战士");
            blacklist.Add("QQhxgame", "QQ华夏");
            blacklist.Add("tty3d", "QQ寻仙");
            blacklist.Add("KartRider", "跑跑卡丁车");
            blacklist.Add("Khan2", "成吉思汗2");
            blacklist.Add("cabalmain", "惊天动地");
            blacklist.Add("cdcgames", "特种部队");
            blacklist.Add("LaTaleClient", "彩虹岛");
            blacklist.Add("GVOnline", "大航海时代online");
            blacklist.Add("Freestyle", "街头篮球");
            blacklist.Add("sdo", "超级舞者");
            blacklist.Add("MapleStory", "冒险岛Online");
            blacklist.Add("RoClient", "仙境传说");
            blacklist.Add("ZSOnline", "真三国无双ol");
            blacklist.Add("WorldOfTanks", "坦克世界");
            blacklist.Add("SC2", "星际争霸2国服");
            blacklist.Add("sgol", "三国online");
            blacklist.Add("game", "神魔大陆");
            blacklist.Add("WLOnline", "武林群侠传2");
            blacklist.Add("DDVLobby", "多多疯狂斗地主");
            blacklist.Add("mir3", "传奇3");
            blacklist.Add("popogame", "疯狂石头");
            blacklist.Add("Asgard", "新神之钌域");
            blacklist.Add("LolClient", "英雄联盟");
            blacklist.Add("cstrike16", "175对战平台中的CS");
            blacklist.Add("gameclient", "浩方游戏平台");
            blacklist.Add("gamecap", "27代理");
            blacklist.Add("AAClientOriginal", "AA对战平台");
            blacklist.Add("ArcLive", "ArcLive游戏平台");
            blacklist.Add("Garena", "竞舞台");
            blacklist.Add("MengZone", "MengZone 盟区");
            blacklist.Add("VSClient", "VS竞技游戏平台");
        }

        public string Check(ArrayList pros)
        {
            string s = "";
            foreach (string pro in pros)
            {
                if (blacklist.ContainsKey(pro))
                {
                    s = s + blacklist[pro] + "\r\n";
                }
            }
            return s;
        }
    }
}
