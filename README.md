# NI-VISA C# Practice

## Overview
C#(.NET)에서 NI-VISA를 사용하여 SCPI 명령을 전송하는 기본 예제입니다.

## Environment
- OS: Windows
- .NET: .NET 6 (or 8)
- NI-VISA
- NationalInstruments.Visa (NuGet)

## Description
- ResourceManager를 통해 계측기 세션을 오픈
- SCPI 명령(*IDN?) 전송
- 장비 응답 수신
- 장비 미연결 시 예외 발생 확인

## Note
- 실제 계측기 연결이 필요합니다.
- 예제 주소는 샘플이며 실제 환경에 맞게 수정해야 합니다.
