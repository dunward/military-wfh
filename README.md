<p align="center"><img src="https://img.shields.io/badge/Core-%3E%3D%203.1-brightgreen.svg?style=flat-square&logo=%2Enet"/></p>

## Working From Home Military Developer
재택근무를 하면서 밀린 서류들을 그나마 간단하게 처리하는 프로그램입니다. 더 이상 귀찮았던 재택근무 서류는 안녕~ startDate부터 lastDate까지 아래 이미지와 기간내의 서류들을 자동으로 생성해줍니다. ![image](https://user-images.githubusercontent.com/37071240/111978089-e3c14d80-8b46-11eb-9a2c-a57f8c5d8436.png)

## How to use this?
https://github.com/weisswolfi/military-wfh/releases/tag/2.0 를 설치한뒤 압축을 해제합니다.
사용을 위해 .net core 3.1버전 이상을 요구합니다. https://dotnet.microsoft.com/download 에서 설치할 수 있습니다.
### Windows
윈도우 환경에서는 military-wfh.exe를 실행하면 pdf들을 생성해줍니다.
### Mac
맥 환경에서는 터미널에서 asset폴더로 이동한뒤 아래의 명령어를 터미널에 실행시킵니다.
```
dotnet military-wfh.dll
```

## Guide
data.json에 항목들에 따라서 자동으로 pdf들을 생성해줍니다.
| Key | Description |
| --- | ----------- |
| fontName | pdf에 사용할 폰트명 |
| name | 이름 |
| birth | 생년월일 |
| startDate | 편입일자 |
| division | 소속 병무청 |
| phoneNumber | 연락처 |
| address | 주소(거주지) |
| wfhStartDate | 재택근무를 시작할 날짜 |
| wfhLastDate | 재택근무 마지막 날짜 |
| wfhWorkingStartTime | 근무 시작시간 |
| wfhWorkingEndTime | 근무 종료시간 |
| description | 수행 업무내용  |
| specialMondayDescription | 수행 업무내용(매주 월요일) 비어있을경우 description |
| specialFridayDescription | 수행 업무내용(매주 금요일) 비어있을경우 description |
| ceoName | 대표명 |
| restDates | 연차 날짜들 |

연차일에는 시작시간/종료시간이 적히지 않으며 수행 업무내용은 연차로 대체됩니다.

![sample](images/sample.PNG)
