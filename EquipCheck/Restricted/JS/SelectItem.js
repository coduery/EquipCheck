// JavaScript function for selecting equipment list items on the 
// SelectItem.aspx web page for inclusion into a user's Equipment Checklist.
function selectItem(itemID)
{
    if (itemID.className == "") {
        itemID.className = "highlightItem";
    } else {
        itemID.className = "";
    }

    var selectedItems = document.getElementsByClassName("highlightItem");
    var itemAndDescription;
    var itemAndDescriptionSplit;
    var item;
    var items = "";
    var itemsWithDescription = "";
    for (var i = 0; i < selectedItems.length; i++) {
        itemAndDescription = selectedItems[i].innerHTML;
        itemAndDescriptionSplit = itemAndDescription.substr(0, itemAndDescription.length - 1).split(" - ");
        item = itemAndDescriptionSplit[0];
        if (i < selectedItems.length - 1) {
            items += item + ",";
            itemsWithDescription += itemAndDescription + ",";
        } else {
            items += item;
            itemsWithDescription += itemAndDescription;
        }
    }

    document.getElementById("Selected_items").value = items;
    document.getElementById("Selected_items_and_decriptions").value = itemsWithDescription;
}