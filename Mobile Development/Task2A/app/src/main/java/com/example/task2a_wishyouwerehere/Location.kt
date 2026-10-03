package com.example.task2a_wishyouwerehere

import android.os.Parcel
import android.os.Parcelable

data class Location(
    val title: String,      //locations title
    val imageResId: Int,    //locations image resource ID
    val rating: Float,      //locations rating (0-5)
    val located: String,    //locations address
    val dateVisited: String //locations date of visit
) : Parcelable {

    constructor(parcel: Parcel) : this( //creates location object from the parcel
        parcel.readString() ?: "",  // reads parcels title (will default to empty string)
        parcel.readInt(),   //reads parcels resource image id
        parcel.readFloat(), //reads parcels rating (0-5)
        parcel.readString() ?: "",  //reads parcels located data (will default to empty string)
        parcel.readString() ?: ""   //reads parcels date of visit (will default to empty string)
    )

    override fun writeToParcel(parcel: Parcel, flags: Int) { //writes the objects properties to a parcel
        parcel.writeString(title)           //title
        parcel.writeInt(imageResId)         //imageResId
        parcel.writeFloat(rating)           //rating
        parcel.writeString(located)         //located
        parcel.writeString(dateVisited)     //dateVisited
    }

    override fun describeContents(): Int = 0

    companion object CREATOR : Parcelable.Creator<Location> {
        override fun createFromParcel(parcel: Parcel): Location = Location(parcel) //create a location object from a parcel
        override fun newArray(size: Int): Array<Location?> = arrayOfNulls(size) //creates an array of location objects
    }
}