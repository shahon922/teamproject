# DietDungeon
 오구오9조의 Visual Studio로 만든 Text RPG

 # 프로젝트 소개
 다이어트를 위협하는 맛있는 적과의 전투  
 다이어트를 결심한 팀 오구조 과연 다이어트를 성공 할 수 있을 것인가?

 # 개발기간
 2024.01.09 ~ 2024.01.16

 # 맴버구성
 이재헌님 - 게임 시작 화면, 이름 입력 받기, 상태 보기, Enemy Phase  
 박창현님 - 공격   
 조수정님 - 전투 시작  
 장지희님 - 전투 결과, 휴식 하기, 던전 클리어 보상  

 # 구현 내용

===== 24.1.15.수정 =====
ReadMe 확인_수정

지희님이 올려주신 Main,
창현님이 올려주신 죽은 몬스터 색 코드
병합해서 Main으로 올렸습니다.

모든 파일 namespace DietDungeon

character.cs -> Player.cs로 변경
(파일 삭제하고 파일 복붙 추천)

거의 모든 메서드의 매개변수로 count, spawnMonster를 계속 복사호출해서
아예 static으로 만듬
매개변수 전달 안해도 가능
 
player.Job.Hp = 최대체력
player.Hp = 현재 플레이어 체력

직업별로 최대체력이 달라서
Rest() 에서
maxHP = player.Job.Hp로 변경

✔ 시연영상 찍기전 휴식파트 끝낸 후 Victory와 Lose에서 HP초기화 코드 삭제예정

===== 24.1.16.추가 및 수정 =====  
수정님이 올려주신 branch에서 휴식 하기, 던전 보상 추가  
휴식 하기 = 플레이어의 골드를 사용하여 체력 회복  
던전 보상 = 쓰러뜨린 몬스터 만큼 500골드 추가  

수정  
Victory와 Lose에서 HP초기화 코드 삭제  

수정
Unit.cs에서 AttackResult로 만들어서 관리
-> 몬스터별 사망 문구 지정 가능
Rest, StatusMenu, Victory UI 변경
PlayerMultySkillAttack 만듬
<주의>
PlayerSkillAttack에서 제거된 내용은 오류때문에 제거한거여서 복구X

=LevelUP 추가=
Victory안에 경험치 보상 추가
Unit.cs -> Atk float바꿈 형변환
Unit에 exp 생성
PlayerInfo 레벨업시 if문 추가
levelup함수 추가
StatusMenu UI변경
창현님 Json 병합

Rest, Victory에 MP회복 추가
