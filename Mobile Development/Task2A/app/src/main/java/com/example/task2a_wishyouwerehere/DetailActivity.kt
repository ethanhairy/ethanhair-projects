package com.example.task2a_wishyouwerehere

import android.os.Bundle
import android.util.Log
import android.widget.ImageView
import android.widget.RatingBar
import android.widget.TextView
import androidx.appcompat.app.AppCompatActivity

class DetailActivity : AppCompatActivity() {

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_detail)

        val location = intent.getParcelableExtra("location", Location::class.java) //retrieve object through the Intent

        //log to check if location is null or not
        Log.d("DetailActivity", "Location received: ${location?.title}")

        location?.let { //only run if location is not null, adn will set the information of the location
            findViewById<ImageView>(R.id.detailImage).setImageResource(it.imageResId)
            findViewById<TextView>(R.id.detailTitle).text = it.title
            findViewById<RatingBar>(R.id.detailRating).rating = it.rating
            findViewById<TextView>(R.id.detailLocation).text = it.located
            findViewById<TextView>(R.id.detailDate).text = it.dateVisited
        } ?: run {
            Log.e("DetailActivity", "Received location is null") //log error and finish the activity if location is null
            finish()  //close the activity if location is null
        }
    }
}
