package com.example.task3a_themedallists

import android.annotation.SuppressLint
import android.content.SharedPreferences
import android.os.Bundle
import androidx.appcompat.app.AppCompatActivity
import com.example.task3a_themedallists.databinding.ActivitySavedDataBinding

class SavedDataActivity : AppCompatActivity() {

    private lateinit var binding: ActivitySavedDataBinding
    private lateinit var sharedPreferences: SharedPreferences

    @SuppressLint("SetTextI18n")
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        binding = ActivitySavedDataBinding.inflate(layoutInflater)
        setContentView(binding.root)

        sharedPreferences = getSharedPreferences("TheMedalListsPrefs", MODE_PRIVATE)

        // Retrieve saved data from SharedPreferences
        val name = sharedPreferences.getString("last_name", "N/A")
        val country = sharedPreferences.getString("last_country", "N/A")
        val goldMedals = sharedPreferences.getInt("last_gold", 0)
        val silverMedals = sharedPreferences.getInt("last_silver", 0)
        val bronzeMedals = sharedPreferences.getInt("last_bronze", 0)

        // Display the saved data
        if (name == "N/A") {
            binding.savedTextView.text = name
        } else {
            binding.savedTextView.text = """
                Last Olympian Clicked Saved:
                Name: $name
                Country: $country
                Gold: $goldMedals
                Silver: $silverMedals
                Bronze: $bronzeMedals
            """.trimIndent()
        }
    }
}
