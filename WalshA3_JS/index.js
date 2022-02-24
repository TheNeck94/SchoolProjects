window.onload = function loadDoc() {
    let xmlhttp = new XMLHttpRequest();
    xmlhttp.onreadystatechange = function () {
        
        if (xmlhttp.readyState === 4 && xmlhttp.status === 200) {
            buildList(xmlhttp.responseText); // do something when server responds
        }
    }; 
    xmlhttp.open("GET", "blogPosts.json", true);
    document.getElementById("btnSearch").addEventListener("click", search,);
    document.getElementById("btnReset").addEventListener("click", reset,);
    xmlhttp.send();
   
   
}

let count = 0;

function buildList(text)  {
    let survey = JSON.parse(text);
    let output = document.getElementById("output");
    let postCount = document.getElementById("postCount");
    
    output.innerHTML = "";
    let list = survey.blogPosts;
    let hold = "";
    
        
    for (i=0; i<list.length; i++) {
        
        {newDiv = "<div id=\"" + i + "\"" + "class=\"PostDiv\">";
        newDiv += "<h4> Title </h4><p class=\"title\">" + list[i].blogPostTitle + "</p> ";
        newDiv += "<h6>Author</h6>" +list[i].blogPostAuthor + " ";
        newDiv += "<h6>Post Date</h6><p class=\"postDate\">" +list[i].blogPostDate + "</p> ";
        newDiv += "<h6>Last Edited</h6><p class=\"editDate\">" + list[i].blogPostEdit + "</p>";
        newDiv += "<br>";
        newDiv += "<p>" + list[i].blogPostBody + "</p>";
        newDiv += "<span> <b>Tags:</b>" + showTags(list[i].blogPostTags) + "</span>";
        newDiv += "<b>Likes: </b><span class=\"likes\"> " + list[i].blogPostLikes + "</span>";
        newDiv += "<p> <b>Post Liked By: </b>" + list[i].blogPostLikedBy + "</p>";
        newDiv += "<b>Shares: </b><span class=\"shares\">" + list[i].blogPostShares + "</span>";
        newDiv += "<div class=\"Comments\">" + ShowComments(list[i].blogPostComments) + "</div>"
        newDiv += "</div>";
        hold += newDiv;

        count++;
    }
    }
    output.innerHTML = hold;
    postCount.innerHTML = "Number of Posts: " + count;

}
function ShowComments(content) {
    let comments = "";
    for (j=0; j < content.length; j++){
        comments += "Author: " + content[j].commentAuthor + "<br>";
        comments += content[j].commentDate + "<br>";
        comments += content[j].commentBody + "<br><br>";
    }
    return comments;
}


function showTags(content) {
    let tags ="";
    tags += "<ul>";
    for (j=0; j < content.length; j++) {
        
        tags += "<li class=\"tag\">" + content[j] + "</li>"
    }
    tags += "</ul>"
    return tags;
}


function search() {
    let searchTitle = document.getElementById("txtSearchTitle").value;
    let resultsTitle = document.querySelectorAll(".title");
    let searchTags = document.getElementById("txtSearchTags").value;
    let resultsTags = document.querySelectorAll(".tag");
    let resultsComments = document.querySelectorAll(".Comments");
    let resultsLikes = document.querySelectorAll(".likes");
    let resultsShares = document.querySelectorAll(".shares");
    let fromDate = document.getElementById("dteSearchFromDate").value;
    let toDate = document.getElementById("dteSearchToDate").value;
    let postDates = document.querySelectorAll(".postDate");
    let chkComments = document.getElementById("chkbxHasComments");
    let chkLikes = document.getElementById("chkbxHasLikes");
    let chkShares = document.getElementById("chkbxHasShares");

    for (j=0; j<resultsTitle.length; j++) {resultsTitle[j].parentElement.style.display = "none"} //clears results from previous search

    for (k=0; k < resultsTitle.length; k++) {
        check1 = resultsTitle[k].textContent.toLowerCase();
        
        if (check1.match(searchTitle.toLowerCase()) && searchTitle != ""){
            resultsTitle[k].parentElement.id = "Show";
        }
        else {resultsTitle[k].parentElement.id = "";}
        if (chkComments.checked == true) {
            for (i=0; i<resultsComments.length; i++){
                if ((resultsComments[i].parentElement.id == "Show" || (searchTitle == "" && searchTags == "")) 
                    && resultsComments[i].childElementCount != 0)
                    {resultsComments[i].parentElement.id = "Show";}
                else {resultsComments[i].parentElement.id = "";}
        }}
        
        if (chkLikes.checked == true) {
            for (a=0; a<resultsLikes.length; a++) {
                 if ((resultsLikes[a].parentElement.id == "Show" || (searchTitle == "" && searchTags == "")) && resultsLikes[a].innerHTML != 0){
                    resultsLikes[a].parentElement.id = "Show";
                 }
                 else {
                     resultsLikes[a].parentElement.id = "";
                 }
            }
            }
        
        if (chkShares.checked == true) {
            for (b=0; b<resultsShares.length; b++) {
                if ((resultsShares[b].parentElement.id == "Show" || (searchTitle == "" && searchTags == "")) && resultsShares[b].textContent != "0") {
                    resultsShares[b].parentElement.id = "Show";
                }
                else {
                    resultsShares[b].parentElement.id = "";
                }
            }
            
        }
    }
    
    for (l =0; l < resultsTags.length; l++) {
        check2 = resultsTags[l].textContent.toLowerCase();
        if (check2.match(searchTags) && searchTags != "") {
            ((resultsTags[l].parentElement).parentElement).parentElement.id = "Show";
        }
        
    }
    if (fromDate <= toDate){
    for (m=0; m<postDates.length; m++){ 
        
        if ((postDates[m].textContent >= fromDate && postDates[m].textContent <= toDate)) {
           postDates[m].parentElement.id = "Show";
        }
        
    }
}
else {alert("Invalid input detected, From Date must be before To Date")}
    let postCount = document.getElementById("postCount");
    count = 0;
    for (c=0; c<resultsTitle.length; c++) {
        
        if (resultsTitle[c].parentElement.id == "Show") {
            resultsTitle[c].parentElement.style.display = "block";
            count++;
        }
        else {
            resultsTitle[c].parentElement.style.display = "none";
        }
    }
    postCount.innerHTML = "Number of Posts: " + count;
    
}

function reset(){
    let list = document.querySelectorAll(".title");
    let title = document.getElementById("txtSearchTitle").innerHTML;
    let tags = document.getElementById("txtSearchTags").innerHTML;
    let fromDate = document.getElementById("dteSearchFromDate");
    let toDate = document.getElementById("dteSearchToDate");
    let chkComments = document.getElementById("chkbxHasComments");
    let chkLikes = document.getElementById("chkbxHasLikes");
    let chkShares = document.getElementById("chkbxHasShares");
    let postCount = document.getElementById("postCount");
    
    title = "";
    tags =  "";
    fromDate.value = "";
    toDate.value = "";
    chkComments.checked = false;
    chkLikes.checked = false;
    chkShares.checked = false;
    count = 0;
    for (i=0; i<list.length; i++) {
        list[i].parentElement.style.display = "block";
        count++;
    }
    postCount.innerHTML = "Number of Posts: " + count;
}











