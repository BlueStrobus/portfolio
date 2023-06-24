window.onload = function() {
    // 배경 이미지 리스트
    var backgrounds = [
      
        'img/a1.jpeg',
        'img/a2.jpeg',
        'img/a3.jpeg',
        'img/a4.jpeg',
        'img/a5.jpeg',
        'img/a6.jpeg',
        'img/a7.jpeg',
        'img/a8.jpeg',
        'img/a9.jpeg',
        'img/a10.jpeg',
        'img/a11.jpeg',
        'img/a12.jpeg',
        'img/a13.jpeg',
        'img/a14.jpeg',
        'img/a15.jpeg',
        'img/a16.jpeg',
        'img/a17.jpeg',
        'img/a18.jpeg',
        'img/a19.jpeg',
        'img/a20.jpeg',
        'img/a21.jpeg',
        'img/a22.jpeg',
        'img/a23.jpeg',
        'img/a24.jpeg',
        'img/a25.jpeg'
    ];
  
    // 이름 입력과 화면 표시
    var nameInput = document.getElementById('nameInput');
    var loginButton = document.getElementById('loginButton');
    var logoutButton = document.getElementById('logoutButton');
    var greetingSection = document.getElementById('greetingSection');
    var greeting = document.getElementById('greeting');
  
    loginButton.addEventListener('click', function() {
      var name = nameInput.value;
      if (name) {
        localStorage.setItem('name', name);
        showGreeting(name);
      }
    });
  
    logoutButton.addEventListener('click', function() {
      localStorage.removeItem('name');
      clearGreeting();
    });
  
    var storedName = localStorage.getItem('name');
    if (storedName) {
      showGreeting(storedName);
    }
  
    function showGreeting(name) {
      var greetingText = `안녕하세요,\n${name}님`;
      greeting.textContent = greetingText;
      greetingSection.style.display = 'block';
      nameInput.value = '';
    }
    
  
    function clearGreeting() {
      greetingSection.style.display = 'none';
    }
  
    // 현재 시간 표시
    var timeElement = document.querySelector('.time');
    var dateElement = document.querySelector('.date');
    updateTime();
  
    function updateTime() {
      var now = new Date();
      var time = now.toLocaleTimeString([], { hour: '2-digit', minute: '2-digit' });
      var date = now.toLocaleDateString();
      timeElement.textContent = time;
      dateElement.textContent = date;
      setTimeout(updateTime, 1000);
    }
  
    // 배경 이미지 랜덤으로 설정
    var body = document.querySelector('body');
    setRandomBackground();
  
    function setRandomBackground() {
      var randomIndex = Math.floor(Math.random() * backgrounds.length);
      var randomImage = backgrounds[randomIndex];
      body.style.backgroundImage = 'url(' + randomImage + ')';
    }
  
    // Todo List 항목 추가 및 삭제
    var addButton = document.getElementById('addButton');
    var taskInput = document.getElementById('taskInput');
    var todoList = document.getElementById('todoList');
  
    addButton.addEventListener('click', function() {
      var task = taskInput.value;
      if (task) {
        var listItem = document.createElement('li');
        listItem.textContent = task;
        todoList.appendChild(listItem);
        taskInput.value = '';
      }
    });
  
    todoList.addEventListener('click', function(event) {
      var target = event.target;
      if (target.tagName === 'LI') {
        target.remove();
      }
    });
  
    // 사용자 위치의 지역 이름과 날씨 표시
    var locationElement = document.getElementById('location');
    var temperatureElement = document.getElementById('temperature');
    var descriptionElement = document.getElementById('description');
  
    if ('geolocation' in navigator) {
      navigator.geolocation.getCurrentPosition(function(position) {
        var latitude = position.coords.latitude;
        var longitude = position.coords.longitude;
        getWeather(latitude, longitude);
      });
    }
  
    function getWeather(latitude, longitude) {
      var apiKey = '2cb1a5d57d7229152686cff19c7ed57b';
      var apiUrl = 'https://api.openweathermap.org/data/2.5/weather';
    
      var url = `${apiUrl}?lat=${latitude}&lon=${longitude}&appid=${apiKey}`;
    
      fetch(url)
        .then(function(response) {
          return response.json();
        })
        .then(function(data) {
          // 날씨 데이터를 받아 처리하는 로직을 구현합니다.
          var location = data.name;
          var temperature = data.main.temp;
          var description = data.weather[0].description;
    
          // 받은 데이터를 업데이트합니다.
          locationElement.textContent = location;
          temperatureElement.textContent = temperature;
          descriptionElement.textContent = description;
        })
        .catch(function(error) {
          console.log('Error fetching weather data:', error);
        });
    }
    
  
      // 하단 명언 랜덤으로 바뀌게 해줘
  var quotes = [
    "성공의 비결은 단 한 가지, 잘해야 하는 일에 모든 열정을 쏟아붓는 것이다. - 톰 존스",
    "당신이 할 수 있다고 믿든 할 수 없다고 믿든, 믿는 대로 될 것이다. - 헨리 포드",
    "기회는 대부분 사람들이 일과 같이 찾아오지 않는다. 문제로 찾아온다. - 토마스 에디슨",
    "행복한 인생은 존재하지 않는다. 행복한 순간들이 있는 인생이다. - 편차드",
    "불가능은 소심한 자의 환상, 비겁한 자의 피할 수 없는 현실이다. - 나폴레옹 보나파르트"
  ];

  var quoteElement = document.getElementById('quote');
  setRandomQuote();

  function setRandomQuote() {
    var randomIndex = Math.floor(Math.random() * quotes.length);
    var randomQuote = quotes[randomIndex];
    quoteElement.textContent = randomQuote;
  }
}


// 위의 코드는 명언을 포함한 모든 요구사항을 처리하기 위해 추가되었습니다. quotes 배열에 다양한 명언을 추가하고, setRandomQuote 함수를 사용하여 화면에 랜덤한 명언을 표시합니다. 이를 위해 HTML 파일에 <p id="quote"></p> 요소를 추가해야 합니다.

// 중요한 점은 날씨 정보를 가져오는 API 요청의 구체적인 내용은 코드에서 구현되어 있지 않으며, API 요청 후 받은 데이터를 사용하여 getWeather 함수를 수정해야 합니다. 날씨 API를 사용하는 방법은 해당 API의 문서를 참조하시기 바랍니다.