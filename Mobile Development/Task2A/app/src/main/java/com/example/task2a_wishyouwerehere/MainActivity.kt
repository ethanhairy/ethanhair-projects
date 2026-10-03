package com.example.task2a_wishyouwerehere

import android.content.Intent
import android.os.Bundle
import android.util.Log
import androidx.appcompat.app.AppCompatActivity
import androidx.recyclerview.widget.LinearLayoutManager
import androidx.recyclerview.widget.RecyclerView

class MainActivity : AppCompatActivity() {

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)

        val locations = listOf( //Creates list of Locations
            //each of the locations contains a title, image resource, rating, address, and date visited
            Location("Williams Landing Station", R.drawable.williamslanding, 4.5f, "Williams Landing VIC 3027", "05/11/2024"),
            Location("Sanctuary Lakes Shopping Centre", R.drawable.slakes, 3.0f, "Point Cook VIC 3030", "12/12/2024"),
            Location("100 Steps of Federation", R.drawable.hundredsteps, 5.0f, "Altona Meadows VIC 3028", "8/10/2024"),
            Location("Alamanda Oval", R.drawable.alamanda, 4.2f, "Point Cook VIC 3030", "20/12/2024")
        )

        val recyclerView: RecyclerView = findViewById(R.id.recyclerView)
        recyclerView.layoutManager = LinearLayoutManager(this) //linear layout manager to arrange items vertically
        //sets the adapter for the RecyclerView to bind the list of locations to the UI
        recyclerView.adapter = LocationAdapter(locations) { location ->
            Log.d("MainActivity", "Location clicked: ${location.title}") // confirm location is being clicked, and which one is clicked

            val intent = Intent(this, DetailActivity::class.java) //navigates to detail activity
            intent.putExtra("location", location) //pass the location object as a parcelable
            startActivity(intent) //will start the DetailActivity to view the locations extra info
        }
    }
}