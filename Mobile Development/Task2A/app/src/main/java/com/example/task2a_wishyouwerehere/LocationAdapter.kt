package com.example.task2a_wishyouwerehere

import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.ImageView
import android.widget.RatingBar
import android.widget.TextView
import androidx.recyclerview.widget.RecyclerView

class LocationAdapter(
    private val locations: List<Location>, //locations list to be displayed
    private val onItemClicked: (Location) -> Unit //handles item clicks
) : RecyclerView.Adapter<LocationAdapter.LocationViewHolder>() {

    inner class LocationViewHolder(view: View) : RecyclerView.ViewHolder(view) {
        //references to the ui elements of each location
        val imageView: ImageView = view.findViewById(R.id.imageView)
        val titleTextView: TextView = view.findViewById(R.id.titleTextView)
        val ratingBar: RatingBar = view.findViewById(R.id.ratingBar)
    }

    //Creates new views
    override fun onCreateViewHolder(parent: ViewGroup, viewType: Int): LocationViewHolder {
        //new views which define the locations UI elements
        val view = LayoutInflater.from(parent.context).inflate(R.layout.item_location, parent, false)
        return LocationViewHolder(view)
    }

    override fun onBindViewHolder(holder: LocationViewHolder, position: Int) { //binds data to a specific ViewHolder
        val location = locations[position]
        //Sets the image, title, and rating for the current location
        holder.imageView.setImageResource(location.imageResId)
        holder.titleTextView.text = location.title
        holder.ratingBar.rating = location.rating
        holder.itemView.setOnClickListener { onItemClicked(location) } //handles clicks on the this locations item
    }

    override fun getItemCount(): Int = locations.size //returns item amount in list, number of items shown in the recycler
}
