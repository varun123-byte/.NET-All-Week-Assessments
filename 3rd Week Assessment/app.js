window.onload = () => 
{
	const form1 = document.querySelector("#addForm");
	let items = document.getElementById("items");
	let submit = document.getElementById("submit");
	let editItem = null;
	form1.addEventListener("submit", addItem);
	items.addEventListener("click", removeItem);
	itemlist.addEventListener("click",checkbox);
};

function addItem(e) 
{
	e.preventDefault();
	if (submit.value != "Submit") 
    {
		editItem.target.parentNode.childNodes[0].data = document.getElementById("item").value;
		submit.value = "Submit";
		document.getElementById("item").value = "";
		document.getElementById("lblsuccess").innerHTML = "Text edited successfully";
		document.getElementById("lblsuccess").style.display = "block";
		document.getElementById("lblsuccess").style.color = "white";
		setTimeout(function() 
        {
			document.getElementById("lblsuccess").style.display = "none";
		}, 3000);
		return false;
	}

	let newItem = document.getElementById("item").value;
	if (newItem.trim() == "" || newItem.trim() == null)
    {
		return false;
    }
	else
    {
		document.getElementById("item").value = "";
		const taskcheckbox = document.createElement('input');
		taskcheckbox.type='checkbox';
		taskcheckbox.className = "task-checkbox	float-start";
		// listitem.appendChild(taskcheckbox);
		// checkbox.appendChild(document.createTextNode("checkbox"));
        let listitem = document.createElement("li");
        listitem.className = "head5 text-center text-white list-group-item w-50 bg-success border rounded-5 mt-3 border-success border-5";
        let deleteButton = document.createElement("button");
        deleteButton.className = "btn-danger btn btn-sm float-end delete border rounded-5";
        deleteButton.appendChild(document.createTextNode("Delete"));
        let editButton = document.createElement("button");
        editButton.className = "btn-dark btn btn-sm float-end mx-1 edit border rounded-5";
        editButton.appendChild(document.createTextNode("Edit"));
        listitem.appendChild(document.createTextNode(newItem));
		listitem.appendChild(taskcheckbox);
        listitem.appendChild(deleteButton);
        listitem.appendChild(editButton);
        items.appendChild(listitem);

    }
}


function removeItem(e) 
{
	e.preventDefault();
	if (e.target.classList.contains("delete")) 
    {
		if (confirm("Are you Sure?")) 
        {
			let listitem = e.target.parentNode;
			items.removeChild(listitem);
			document.getElementById("lblsuccess").innerHTML = "Text deleted successfully";
			document.getElementById("lblsuccess").style.display = "block";
			document.getElementById("lblsuccess").style.color = "#fff";
			setTimeout(function() 
            {
				document.getElementById("lblsuccess").style.display = "none";
			document.getElementById("lblsuccess").style.color = "white";

			}, 3000);
		}
	}
	if (e.target.classList.contains("edit")) 
    {
		document.getElementById("item").value = e.target.parentNode.childNodes[0].data;
		submit.value = "EDIT";
		editItem = e;
	}
	// if (e.target.classList.contains("checkbox")) 
    // {
	// 	let listitem = e.target.parentNode;
	// 	items.removeChild(listitem);
	// 	document.getElementById("lblsuccess").innerHTML = "Text deleted successfully";
	// }
}
function toggleButton(ref, btnID) 
{
	document.getElementById(btnID).disabled = false;
}
