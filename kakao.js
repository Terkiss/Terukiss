var ManagerRoom = "테루테루"; // 관리자방
var TargetManageRoom = "그런 제목을 가진 애니는 몰라!"; // 타겟방

var CurrentIndex = 0 ;
var DaysDataIndex =0;

var JournalData = [] ; 

var Deamon = false;

var today = new Date();
var DayData = today.getDate();
var mm = today.getMonth()+1; //January is 0!
var yyyy = today.getFullYear();


var sdcard = android.os.Environment.getExternalStorageDirectory().getAbsolutePath(); 
var NickNameFolder = new java.io.File(sdcard+"/닉네임/"); 
var YearFolder = new java.io.File(sdcard+"/"+yyyy+"/"); 
var MonthFolder = new java.io.File(sdcard+"/"+yyyy+"/"+mm+"/");



//folder.mkdirs(); //sd카드에 학습 폴더를 생성합니다 

NickNameFolder.mkdirs();
YearFolder.mkdirs();
MonthFolder.mkdirs();

function save(folderName,fileName,str)
{ 
  var c=new java.io.File(sdcard+"/"+folderName+"/"+fileName); 
  var d=new java.io.FileOutputStream(c); 
  var e=new java.lang.String(str);
  d.write(e.getBytes()); 
  d.close(); 
} 
function read(folderName,fileName)
{ //파일 읽기 함수 제작 
  var b=new java.io.File(sdcard+"/"+folderName+"/"+fileName); 
  if(!(b.exists())) return null; //만약 읽을 파일이 없다면 null 변환 
  var c=new java.io.FileInputStream(b); 
  var d=new java.io.InputStreamReader(c); 
  var e=new java.io.BufferedReader(d); 
  var f=e.readLine(); 
  var g=""; 
  while((g=e.readLine())!=null)
  { 
    f+="\n"+g; //\ = 역슬래쉬 → 줄바꿈 표시 
  } 
  c.close(); 
  d.close(); 
  e.close(); 
  return f.toString(); //읽은 파일 내용을 반환 
} 
function TextRead(folderName, fileName)
{
    var b=new java.io.File(sdcard+"/"+folderName+"/"+fileName); 

    if(!(b.exists())) return null; //만약 읽을 파일이 없다면 null 변환 
    var c=new java.io.FileInputStream(b); 
    var d=new java.io.InputStreamReader(c); 
    var e=new java.io.BufferedReader(d); 
    //var f=e.readLine(); 
    var g=""; 

    var i = 0;
    var arr = [];
    while((g=e.readLine())!=null)
    { 
        //f+="\n"+g; //\ = 역슬래쉬 → 줄바꿈 표시 
        arr[i] = g;
        i++;
    } 
    c.close(); 
    d.close(); 
    e.close(); 
    return arr; //읽은 파일 내용을 반환 
}


function response(room, msg, sender, isGroupChat, replier) 
{
   if(msg.indexOf("!Deamon ON") == 0)
   {
       
       var NickName =TextRead("닉네임", "NickName.txt");
       
       var TalkJournal = TextRead(yyyy+"/"+mm, DayData+".txt" );
       
       if(NickName == null|| TalkJournal == null)
       {
                
            Deamon = true;

            FixedUpdate();
            return null;
       }

       for(var i = 0; i< TalkJournal.length; i++)
       {
            Api.replyRoom(ManagerRoom, TalkJournal[i]);
       }

       if(DayData == today.getDate())
       {
           // 당일 기준
            for(var i = 0; i < NickName.length; i++)
            {
                // 객체 생성
                JournalData[i] = new info();

                JournalData[i].Name = NickName[i];
                JournalData[i].TalkNumber = 0;
                JournalData[i].TalkData = "";
                
                for(var j = 0 ; j <TalkJournal.length; j++ )
                {
                    

                    var tempData = TalkJournal[j].split("|");
                    if(NickName[i] == tempData[0].substr(0))
                    {
                        // 닉넴 테이블에 해당 닉네임이 있을경우 처리
                        JournalData[i].Name = tempData[0].substr(0);
                        if(tempData[1] > 0 )
                        {
                            JournalData[i].TalkNumber = tempData[1];
                            JournalData[i].TalkData = tempData[2];
                        }
                    }
            
                }
            
            }

            // 인덱스 초기화  명령이 초기화 되면 이것이 반드시 실행이 되어야 합니다.
            CurrentIndex = JournalData.length - 1;




       }
       else
       {
           DayData = today.getDate();
            // 당일이 아닌기준 메세지가 왔을떄 처리
            // 변수의 초기화 필요 닉네임이 로드된 상태면 변수를 다 날리는 것보단
            // 내부 정보 변수를 날릴기만 하면될것
            if(JournalData.length > 0)
            {
                for(var i =0; i < JournalData.length; i++)
                {
                    JournalData[i].TalkNumber = 0;
                    JournalData[i].TalkData = "";
                }
            }
            else
            {
                JournalData = [] ;
                // for(var i = 0; i < NickName.length; i++)
                // {
                
                //     JournalData[i].Name = NickName[i];
                // }
            }
            
       }

      Deamon = true;

      FixedUpdate();
   }
   if(msg.indexOf("!Deamon OFF") == 0)
   {
        Deamon = false;
        JournalData = [];
   }
   if( TargetManageRoom == room )
   {   //메시지가 게애종 에서 왓다면
        var NickNameCheck = false;
        if(JournalData.length > 0)
        {
            for(var i = 0 ; i < JournalData.length; i++)
            {
                if(JournalData[i].Name == sender)
                {
                    NickNameCheck = true;
                }
            }
        }
        

        if(NickNameCheck )
        {
            // Api.replyRoom(ManagerRoom, "테스트 1 게애종 방에서 문자옴.");
            // Api.replyRoom(ManagerRoom, "현재 저널 데이터 변수 ");
            // Api.replyRoom(ManagerRoom, JournalData.length);
        
            
            for(var i = 0 ; i < JournalData.length; i++)
            {
                if(JournalData[i].Name == sender)
                {
                    JournalData[i].TalkNumber = JournalData[i].TalkNumber + 1;
                    JournalData[i].TalkData = JournalData[i].TalkData+ ","+msg;
                }
                // else
                // {
                //     // 현재 리스트에 닉넴이 없거나 있으실경우 호출되는 영역 
                //     // 사실 위 deamon 영역 에서 정의된 함수영역이 여기서 ㅈ저장 되어야 했던 거엿음
                //     // 새로운 사용자가 대화를 시전 한경우 
                //     JournalData[CurrentIndex].Name = sender;
                //     JournalData[CurrentIndex].TalkNumber = JournalData[CurrentIndex].TalkNumber + 1;
                //     JournalData[CurrentIndex].talkData = JournalData[CurrentIndex].TalkData+","+msg;
    
                // }
            }
        }
        else 
        {
            CurrentIndex++;

            JournalData[CurrentIndex] = new info();

            JournalData[CurrentIndex].Name = sender;
            JournalData[CurrentIndex].TalkNumber = JournalData[CurrentIndex].TalkNumber + 1;
            JournalData[CurrentIndex].talkData = JournalData[CurrentIndex].talkData + ","+msg;
        }
        
   }
   if(msg.indexOf("!뷰") == 0 && ManagerRoom == room)
   {
        View();
   }
}

function View()
{
    for(var i =  0 ; i < JournalData.length; i++)
    {
        Api.replyRoom(ManagerRoom, "방목록 뷰 명령입니다.");
        Api.replyRoom(ManagerRoom, "닉네임 : "+JournalData[i].Name);
        var talkData = JournalData[i].talkData.split(",");
        var talkSubData = "";
        for(var j = 0; i < talkData.length; j++)
        {
            if(j % 5 == 0)
            {
                talkSubData = talkSubData + "\n";
            }
            talkSubData += talkData[i] + "," ;
        }
        Api.replyRoom(ManagerRoom, "대화횟수 : " + JournalData[i].TalkNumber);
        Api.replyRoom(ManagerRoom, "대화 내용 ::: "+talkSubData);
        
    }
}



function SpeakerChecker()
{
    while(true)
    {

    }
}



function FixedUpdate() 
{
    // dd = today.getDate();
    // if(Deamon == true)
    // {
    //     var SaveData ="";
    //     for(var i =0; i < JournalData.length; i++)
    //     {
    //         SaveData +="*"+JournalData[i].Name+"|"+JournalData[i].TalkNumber+"|"+JournalData[i].TalkData+"\n";
    //     }
    //     save(yyyy+"/"+mm, dd+".txt",SaveData);
    //     delay(60000);
    //     FixedUpdate();
    // }
    // else
    // {
    //     return;
    // }
    while(true)
    {
        delay(60000);
        //DayData = today.getDate();
        if(Deamon == true)
        {
            Api.replyRoom(ManagerRoom, "Auto Save 실행");
            var SaveData ="";
            if(DayData == today.getDate() )
            {
            
                Api.replyRoom(ManagerRoom, "당일 Auto Save 진입");
                for(var i =0; i < JournalData.length; i++)
                {
                    SaveData +="*"+JournalData[i].Name+"|"+JournalData[i].TalkNumber+"|"+JournalData[i].TalkData+"\n";
                }
                save(yyyy, DayData+".txt",SaveData);
                Api.replyRoom(ManagerRoom, "당일 Auto Save 성공");
            }
            else
            {
                Api.replyRoom(ManagerRoom, "다음날 Auto Save 진입");
                for(var i =0; i < JournalData.length; i++)
                {
                    SaveData +="*"+JournalData[i].Name+"|"+JournalData[i].TalkNumber+"|"+JournalData[i].TalkData+"\n";
                }
                save(yyyy, DayData+".txt",SaveData);
                Api.replyRoom(ManagerRoom, "다음날 Auto Save 성공");

                // 구조체 배열 초기화
                for(var i = 0 ; i < JournalData.length; i++)
                {
                    JournalData[i].TalkNumber = 0;
                    JournalData[i].TalkData ="";
                }
            }
            
            
            //save(yyyy+"/"+mm, dd+".txt",SaveData);
            //Api.replyRoom(ManagerRoom, "Auto Save 성공");
        }
        else
        {
            return;
        }
    }
    
 
}


function delay(gap){ /* gap is in millisecs */ 

    var then,now; 
   var TimeObject = new Date();
    then=new Date().getTime(); 
  
    now=then; 
  
    while((now-then)<gap){ 
  
      now=new Date().getTime();  // 현재시간을 읽어 함수를 불러들인 시간과의 차를 이용하여 처리 
      //now= TimeObject.getTime();
    } 
  
  } 
  


// 데이터 관리를 위한 함수 
function info()
{

   var Name = '';
   
   var TalkNumber = 0;
   
   var NameState = 0; // 0 : clear , 1 : Soljer 2: BAN
   
   var TalkData = "";
   //Valid for the corresponding query
}

function JournalList()
{
    var Head = null;
}

function MessageNode(Name, msg)
{
    var Next = null;
    var Nick = Name;
    var Message = msg;
    var TalkNumber = 0;
}


function LinkedList()
{
    var length = 0;
    var Head = null;
    var TalkRank = new Array(3); // 0 : 1등,  1: 2등, 3 : 3등
    // 수정 삭제
    // 입력 출력
    // 말할시 자도입력
    // 정렬
    // 사입정렬
    // 퀵정렬
    // 버플정령

}

LinkedList.prototype.append =function(Name, Msg) 
{
    var nord = new MessageNode(Name, Msg); 
    var curr; 
    if( this._head == null ) 
    { 
        this._head = node;
    } 
    else 
    { 
        curr = this._head; 
        
        while( curr.next ) 
        { 
            curr = curr.next; 
        } 
        curr.next = node; 
    } 
    this._length ++;
 }; 
//  var list = new LinkedList(); 
//  list.append(15); 
//  list.append(10);



LinkedList.prototype.removeAt = function(_Position) 
{
    if( _Position > -1 && _Position < this._length ) 
    {
        var curr = this._head;
        var prev, index = 0;

        if( _Position === 0 ) {
            this._head = curr.next;
        } else {
            while( index++ < _Position ) {
                prev = curr;
                curr = prev.next;
            }

            prev.next = curr.next;
        }

        this._length --;

        curr.next = null;

        return curr.data;
    }

    return null;
};

LinkedList.prototype.indexOf = function(Name) 
{ 
    var curr = this._head, index = -1; 
    
    while( curr ) 
    { 
        if( curr.Name === Name ) 
        { 
            return index; 
        } 
        index ++; 
        curr = curr.next; 
    } 
    return -1; 
};

LinkedList.prototype.remove = function(data) 
{ 
    var index = this.indexOf(data); 
    return this.removeAt(index); 
};

LinkedList.prototype.Clean() = function()
{
    this.Head = null; 

    if(this.Head != null)
    {
        return -1;
    }
    return 1;
}

LinkedList.prototype.size = function() 
{ 
    return this._length;  
};

LinkedList.prototype.modify = function(Name, Msg, Ranks) 
{ 
    var curr = this.Head, index = -1; 
    
    while( curr ) 
    { 
        if( curr.Name === Name ) 
        { 
            return index;
            curr.Name 
        } 
        index ++; 
        curr = curr.next; 
    } 
    return -1; 
};


//출처: https://boycoding.tistory.com/33 [소년코딩]



function Find(data)
{
 
}

function ADD(data)
{
    
}

