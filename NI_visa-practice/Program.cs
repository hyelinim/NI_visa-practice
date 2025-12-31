// NI-VISA의 Formatted I/O 기능을 사용하기 위한 네임스페이스
// SCPI 명령을 문자열 단위로 Write / Read 할 수 있게 해줌
using Ivi.Visa.FormattedIO;

// NI-VISA 핵심 API (ResourceManager, Session 등)
using NationalInstruments.Visa;

// 기본 시스템 네임스페이스 (Console 등)
using System;

class Program
{
    static void Main()
    {
        // 계측기 주소(Resource String)
        // VISA가 어떤 장비에 연결할지 식별하는 "주소"
        // 여기서는 TCP/IP 기반 계측기를 가정한 예시 주소
        string address = "TCPIP0::192.168.0.10::INSTR";

        // VISA 리소스 관리자 생성
        // → PC에 연결된 모든 VISA 장비를 관리하는 진입점
        using var rm = new ResourceManager();

        // 지정한 주소의 계측기와 통신 세션을 연다
        // 이 시점에 실제로:
        // - 장비 존재 여부 확인
        // - 통신 포트 오픈
        // - 드라이버/VISA 레이어 접근
        using var session = (MessageBasedSession)rm.Open(address);

        // Message 기반 통신을 쉽게 하기 위한 I/O 객체 생성
        // 실제 SCPI 문자열 송수신은 이 객체가 담당
        var io = new MessageBasedFormattedIO(session);

        // 계측기에 SCPI 명령 전송
        // *IDN? : 모든 SCPI 계측기가 공통으로 지원하는
        //         "제조사, 모델명, 시리얼, 펌웨어 버전" 질의 명령
        io.WriteLine("*IDN?");

        // 계측기가 보낸 응답을 한 줄 읽어옴
        // 장비가 없거나 응답이 없으면 여기서 대기/에러 발생 가능
        string response = io.ReadLine();

        // 계측기 응답 출력
        Console.WriteLine(response);

        //깃허브 실습 줄
        //깃허브 실습 2줄
    }
}
