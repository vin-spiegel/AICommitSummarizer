using OpenAI;
using OpenAI.Chat;

namespace AiCommitSummarizer.Core;

public class Prompt
{
    public static List<Message> GetPrompt()
    {
        return new List<Message>
        {
            new(Role.System, @"
As an AI specialist in summarizing Git commit logs, 
your task is to group multiple commits related to the same task and summarize each task into a single sentence.

Guidelines:
1. Exclude commits relating to refactoring and CI/CD operations. They are not part of the summary.
2. Only target commits that address bug fixes, new features, tests, etc.
3. Make sure to consolidate multiple commits that share the same workflow into one and summarize it concisely. You are allowed to abstract if you see tasks that seem similar.
4. The required output format is: {name} - {summary}."), 
            new(Role.User, @"
240301 - D.Spiegel - 회원 가입 기능 추가
240301 - D.Spiegel - 서버 - 회원 가입 기능 연동                                         
240301 - D.Spiegel - LoginUI button 컴포넌트 추가                                       
240301 - D.Spiegel - 프로덕션 환경에서 로그인 프로세스 활성화                  
240208 - review@review.com - [Jenkins] Creator Version Up                      
240208 - review@review.com - [Jenkins] Creator Version Up                      
240302 - D.Spiegel - fix UserManager Firebase 이벤트 핸들링 부분 예외처리            
240302 - D.Spiegel - Client.logoutCallback 튜플 리턴 추가                        
240207 - review@review.com - [Jenkins] Creator Version Up                      
240304 - D.Spiegel - 알림창 위치 설정 프로퍼티 추가
240304 - D.Spiegel - PopupAlert 메소드 체이닝, 위치 조정 메서드 추가
240305 - D.Spiegel - ClickableText 코드 정리
240305 - D.Spiegel - 서버와의 일관성을 위해 onLogout 이벤트 수정
240306 - D.Spiegel - 유저 데이터 관련 스크립트 정리
240307 - D.Spiegel - fix compile error
240307 - D.Spiegel - 유니티 제작 게임 레벨 갱신 쿼리 추가
240307 - D.Spiegel - 레벨에 EXP 타입 추가
240207 - D.Atom - 유니티 제작 게임 장르 갱신 쿼리 추가
240207 - D.Atom - 장르에 ETC 타입 추가
"), 
            new(Role.System, @"
Spiegel - 회원 가입 기능 개선 및 알림창 위치 설정 작업
Spiegel - onLogout 이벤트 일관성 유지
Atom - 게임 레벨 기능 확장 작업 및 유니티 레벨 추가
".Trim()),
            new(Role.User, @"
240401 - D.Spiegel - 결제 시스템 추가
240401 - D.Spiegel - 서버 - 결제 시스템 연동
240401 - D.Spiegel - PaymentUI cofirmButton 컴포넌트 추가
240401 - D.Spiegel - 프로덕션 환경에서 결제 프로세스 활성화
240402 - review@review.com - [Jenkins] Creator Version Up
240402 - review@review.com - [Jenkins] Creator Version Up
240402 - D.Spiegel - fix PaymentManager Paypal 이벤트 핸들링 부분 예외처리
240402 - D.Spiegel - Client.refundCallback 튜플 리턴 추가
240403 - review@review.com - [Jenkins] Creator Version Up
240404 - D.Spiegel - 결제 창 위치 설정 프로퍼티 추가
240404 - D.Spiegel - PopupPayment 메소드 체이닝, 위치 조정 메서드 추가
240405 - D.Spiegel - PaymentText 코드 정리
240405 - D.Spiegel - 서버와의 일관성을 위해 onRefund 이벤트 수정
240406 - D.Spiegel - 결제 데이터 관련 스크립트 정리
240407 - D.Spiegel - fix compile error
240407 - D.Tom - 유니티 제작 게임 아이템 갱신 쿼리 추가
240407 - D.Tom - 아이템에 rare 타입 추가
"), 
            new(Role.System, @"
Spiegel - 결제 시스템 개선 및 위치 설정 작업
Spiegel - onRefund 이벤트 일관성 유지
Tom - 게임 아이템 기능 확장 및 유니티 아이템 추가
".Trim()),
        };
    }
}