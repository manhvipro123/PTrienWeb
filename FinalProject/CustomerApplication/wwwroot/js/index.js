let item = [{ name: "Bao Cao Su Durex Invisible Extra Thin, Extra Lubricated Hộp 10 Cái", image:"/assets/images/1.png"},
    { name: "Bao Cao Su Durex Invisible Extra Thin Extra Sensitive Hộp 10 Cái", image: "/assets/images/2.png"},
    { name: "Bao Cao Su Durex Invisible Extra Thin Extra Sensitive Hộp 3 Cái", image: "/assets/images/3.png"},
    { name: "Bao cao su Durex Fether Ultima hộp 12 Cái", image: "/assets/images/4.png"},
    { name: "Bao Cao Su Durex Fether Ultima Hộp 3 Cái", image: "/assets/images/5.png"},
    { name: "Bao Cao Su Durex Fetherlite Hộp 12 Cái", image: "/assets/images/6.png"},
    { name: "Bao Cao Su Durex Fetherlite Hộp 3 Cái", image: "/assets/images/7.png"},
    { name: "Bao Cao Su Durex Performa Hộp 12 Cái", image: "/assets/images/8.png"},
    { name: "Bao Cao Su Durex Performa Hộp 3 Cái", image: "/assets/images/9.png"},
    { name: "Bao Cao Su Durex Pleasuremax Hộp 12 Cái", image: "/assets/images/10.png"},
    { name: "Bao Cao Su Durex Pleasuremax Hộp 3 Cái", image: "/assets/images/11.png"},
    { name: "Bao Cao Su Durex Kingtex Hộp 12 Cái", image: "/assets/images/12.png" },
]

let itemBox = document.getElementsByClassName("items");
let count = item.length;
let totalItem = document.getElementById("total");
console.log(totalItem);
totalItem.innerHTML = count + " SẢN PHẨM";

for(let i = 0; i < item.length; i++){
    let nameLable = document.createElement("h3");
    let imageLable = document.createElement("img");
    
    let itemDiv = document.createElement("div");
    itemDiv.className = "itemDiv";
    
    nameLable.innerHTML = item[i].name;
    imageLable.src = item[i].image;
    itemDiv.appendChild(imageLable);
    itemDiv.appendChild(nameLable);
    itemBox[0].appendChild(itemDiv);
}