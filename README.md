# iot-wpf-2025
Iot 개발자 WPF 학습리포지토리 2025 

## 1일차 

### WPF 개요
- Windows Presentaion Foundation
    - WinForms의 디자인의 미약한 부분, 속도개선, `개발과 디자인의 분리` 개선하고자 MS 프레임워크
    - 화면 디자인을 XML기반의 xaml

### WPF DB바인딩 연습 - [소스](./day01/Day01Wpf/WpfBasicApp01/MainWindow.xaml), [소스](./day01/Day01Wpf/WpfBasicApp01/MainWindow.xaml.cs)
1. 프로젝트 생성
2. NuGet패키지에서 `MahApps.Metro`(디자인) 라이브러리 설치
3. 디자인 영역
    - App.xaml
    - MainWindow.xaml
    - MainWindow.xaml.cs의 기반클래스를 변경하는 것 - 디자인
4. UI구현
5. DB연결 사전준비
    - NuGet패키지에서 `MySQL.Data` 라이브러리 설치
6. DB연결
    1. DB연결문자열(Connection String) : DB종류마다 연결문자열 포맷이 다르고 무조건 있어야함
    2. 쿼리(옵션) : 실행할 쿼리(보통 SELECT, INSERT, UPDATE, DELETE)
    3. 데이터를 담을 객체 : 리스트 형식 
    4. DB연결객체 (`SqlConnection`) : 연결문자열을 처리하는 객체. DB연결, 끊기, 연결확인...
        - DB종류별로, MySqlConnection, SqlConnection, OracleConnection...
    5. DB명령객체(`SqlCommand`) : 쿼리를 컨트롤하는 객체, 생성시 쿼리와 연결객체
        - ExecuteReader() : SELECT문 실행, 결과데이터를 담는 메서드
        - ExecuteScalar() : SELECT문 중 count() 등 함수로 1row/1column 데이터만 가져오는 메서드
        - ExecuteNonQuery() : INESRT, UPDATE, DELETE 문과 같이 transaction이 발생하는 쿼리실행 사용 메서드 
    6. DB데이터어댑터(`SqlDataAdapter`) : 연결이후 데이터처리를 쉽게 도와주는 객체
        - DB명령객체처럼 쿼리를 직접싱행할 필요없음
        - DataTable, DataSet객체에 fill()메서드로 자동으로 채워줌
        - 거의 SELECT문에만 사용
    7. DB데이터리더(`SqlDataReader`)
        - DataReader : ExecuteReader()로 가져온 데이터를 조작하는 객체
        - DataAdapter : 좀더 간단하게 데이터를 처리해주는 객체

7. 실행결과

    <img src="./image/wpf0001.png" width="600">

8. MahApps.Metro 방식 다이얼 로그 처리  

    <img src="./image/wpf0004.png" width="600">

9. `전통적인 C# 윈앱개발`과 차이가 없음



### WPF MVVM
- [디자인패턴](https://ko.wikipedia.org/wiki/%EC%86%8C%ED%94%84%ED%8A%B8%EC%9B%A8%EC%96%B4_%EB%94%94%EC%9E%90%EC%9D%B8_%ED%8C%A8%ED%84%B4)
    - 소프트웨어 공학에서 공통적으로 발생하는 문제를 재상용 가능하게 해결한 방식들
    - 반복적으로 되풀이되는 개발디자인의 문제를 해결하도록 맞춤화시킨 양식(템플릿)
    - 여러 디자인패턴 중, 아키텍쳐패턴, 그 중 디자인과 개발을 분리해 개발할 수 있는 패턴을 준비
        - MV* : MVC, MVP, MVVM...

- MVC : Modeol View Contorller 패턴
    - 사용자 인터페이스(View)와 비즈니스 로직(Controller, Model) 분리해서 앱을 개발
    - 디자이너에게 최소한의 개발에 참여를 시킴
    - 개발자는 디자인은 고려하지 않고 개발만 할 수 있음
    - 사용자는 Contorller에게 요청
    - Controller가 Model에서 DB에 있는 데이터를 가져옴
    - Model이 DB에 데이터를 가져와 Controller로 전달
    - Controller는 데이터를 비즈니스로직에 따라 처리하고 View로 전달
    - View는 데이터를 화면에 뿌려주고, 화면상에 처리할 것을 마친 후 사용자에게 응답

    - 구조는 복잡, 각 부분별 개발코드는 간결
    - Spring Boot, APS.NET, jDango 등 웹개발 아키텍처패턴으로 표준으로 사용 

    <img src="./image/wpf0002.png" width="600">

- MVP : Model-View-Presenter 패턴
    - MVC 패턴에서 파생됨
    - presenter : Supervising Controller라고 부름

- **MVVM** : Model-View-ViewModel 패턴
    - MVC 패턴에서 파생
    - 마크업언어로 GUI코드를 구현하는 아키텍처
    - 사용자는 View로 접근(MVC와 차이점)
    - ViewModel이 Controller 역할(비즈니스로직 처리)
    - Model은 당연히 DB요청, 응답
    - 연결방식 MVC와 다름
    - 전통적인 C# 방식은 사용자가 이벤트발생시키기 때문에 발생시기를 바로 알 수 있음
    - MVVM 방식은 C#이 변화를 주시하고 있어야 함. 상태가 바뀌면 변화를 줘야함 

    <img src="./image/wpf0003.png" width="600">

### WPF MVVM 연습
1. 프로젝트 생성 - [소스](./day01/Day01Wpf/WpfBasicApp02/View/MainWindow.xaml) [소스](./day01/Day01Wpf/WpfBasicApp02/ViewModel/MainViewModel.cs)
2. WPF DB바인딩 연습시 사용한 UI 복사
3. Model, View, ViewModel 폴더 생성
4. MainWindow.xaml을 View로 이동
5. App.xaml StrtupUri 수정
6. Model폴더 내 Book클래스 생성
    - INotifyPropertyChanged 인터페이스 : 객체내의 어떠한 속성값이 변경되면 상태를 C#에게 알려주는 기능
    - PropertyChangedEventHandler 이벤트 생성
7. ViewModel폴더 내 MainViweModel클래스 생성




## 2일차

## 3일차

## 4일차 

## 5일차 

## 6일차