package com.example.task3a_themedallists

import android.content.Intent
import android.content.SharedPreferences
import android.os.Bundle
import android.view.Menu
import androidx.appcompat.app.AppCompatActivity
import androidx.recyclerview.widget.LinearLayoutManager
import com.example.task3a_themedallists.databinding.ActivityMainBinding
import com.google.android.material.snackbar.Snackbar

class MainActivity : AppCompatActivity() {

    private lateinit var binding: ActivityMainBinding
    private lateinit var sharedPreferences: SharedPreferences
    private val dataList = mutableListOf<OlympianData>()

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        binding = ActivityMainBinding.inflate(layoutInflater)
        setContentView(binding.root)
        //Setting up and defining SharedPreferences
        sharedPreferences = getSharedPreferences("TheMedalListsPrefs", MODE_PRIVATE)

        setSupportActionBar(binding.toolbar)

        loadDataFromFile() //load data

        //set up RecyclerView and snackbar
        val adapter = OlympianAdapter(dataList) { olympian ->
            saveLastClickedData(olympian)
            Snackbar.make(binding.root, "(${olympian.country}) ${olympian.name}: Gold Medals ${olympian.goldMedals}", Snackbar.LENGTH_LONG).show()
        }
        binding.recyclerView.layoutManager = LinearLayoutManager(this)
        binding.recyclerView.adapter = adapter
    }

    private fun loadDataFromFile() {
        val inputStream = assets.open("data.txt") //opening file and converting it to input stream to be read
        inputStream.bufferedReader().useLines { lines -> //buffering character and reading line by line
            lines.forEach { line ->
                val parts = line.split(",") //comma for delimiter
                if (parts.size == 5) {
                    val name = parts[0].trim()
                    val country = parts[1].trim()
                    val goldMedals = parts[2].toIntOrNull() ?: 0
                    val silverMedals = parts[3].toIntOrNull() ?: 0
                    val bronzeMedals = parts[4].toIntOrNull() ?: 0
                    //determine the flag image based on country
                    val flagResId = when (country) {
                        "USA" -> R.drawable.usa
                        "New Zealand" -> R.drawable.nz
                        "Australia" -> R.drawable.aus
                        "Jamaica" -> R.drawable.jm
                        else -> 0 //no image if flag isn't in the list of possible flags
                    }
                    //add Olympian to dataList
                    dataList.add(OlympianData(name, country, goldMedals, silverMedals, bronzeMedals, flagResId))
                }
            }
        }
    }

    private fun saveLastClickedData(olympian: OlympianData) {
        with(sharedPreferences.edit()) {
            putString("last_name", olympian.name)
            putString("last_country", olympian.country)
            putInt("last_gold", olympian.goldMedals)
            putInt("last_silver", olympian.silverMedals)
            putInt("last_bronze", olympian.bronzeMedals)
            apply() //Saved added data into the SharedPreferences
        }
    }

    override fun onCreateOptionsMenu(menu: Menu?): Boolean {
        menuInflater.inflate(R.menu.main_menu, menu)
        return true //ensure menu displayed
    }

    override fun onOptionsItemSelected(item: android.view.MenuItem): Boolean {
        if (item.itemId == R.id.saved_data) { //if menu item clicked
            startActivity(Intent(this, SavedDataActivity::class.java)) //starts SavedDataActivity
            return true
        }
        return super.onOptionsItemSelected(item)
    }
}