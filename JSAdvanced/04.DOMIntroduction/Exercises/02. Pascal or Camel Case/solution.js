function solve() {
  let inputText = document.getElementById("text").value.toLowerCase();
  let namingConvention = document.getElementById("naming-convention").value
  let splittedInput = inputText.split(' ');
  let result = '';

  for (let i = 0; i < splittedInput.length; i++) {
     result += splittedInput[i][0].toUpperCase() + splittedInput[i].slice(1);
    }

  if (namingConvention == 'Camel Case') {
    result = result[0].toLowerCase() + result.slice(1);
  } else if (namingConvention == 'Pascal Case') {
  } else {
    result = 'Error!';
  }

  document.getElementById("result").textContent = result;
}