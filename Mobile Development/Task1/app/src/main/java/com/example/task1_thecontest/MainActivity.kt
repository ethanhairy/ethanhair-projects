package com.example.task1_thecontest

import android.os.Bundle
import androidx.activity.enableEdgeToEdge
import androidx.appcompat.app.AppCompatActivity
import androidx.core.view.ViewCompat
import androidx.core.view.WindowInsetsCompat
import android.util.Log
import android.media.MediaPlayer
import android.widget.Button
import android.widget.TextView

class MainActivity : AppCompatActivity() {
    private var score = 0
    private lateinit var scoreTextView: TextView
    private lateinit var mediaPlayerClick: MediaPlayer
    private lateinit var mediaPlayerWin: MediaPlayer

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)
        Log.d("MainActivity", "onCreate called")

        scoreTextView = findViewById(R.id.ScoreText) //Scores Text Element

        mediaPlayerClick = MediaPlayer.create(this, R.raw.button_press_short) //loading button sounds
        mediaPlayerWin = MediaPlayer.create(this, R.raw.win_cheer) //loading win sound

        score = savedInstanceState?.getInt("SCORES_KEY") ?: 0 //restore save state, score value
        updateScore() //updates score based off of save

        //button listeners
        findViewById<Button>(R.id.ButtonScore).setOnClickListener { addScore() }
        findViewById<Button>(R.id.ButtonSteal).setOnClickListener { stealScore() }
        findViewById<Button>(R.id.ButtonReset).setOnClickListener { resetScore() }
    }

    private fun addScore() {
        if (score < 15) { //can't score more than 15 (win condition value)
            score += 1
        }
        updateScore()
        mediaPlayerClick.start() //plays button press sound
        checkWinCondition()
        Log.d("GameAction", "Score button clicked. Current score: $score")
    }

    private fun stealScore() {
        if (score > 0) {
            score -= 1
        }
        updateScore()
        mediaPlayerClick.start()
        Log.d("GameAction", "Steal button clicked. Current score: $score")
    }

    private fun resetScore() {
        score = 0 //reset score to 0
        updateScore()
        mediaPlayerClick.start()
        Log.d("GameAction", "Reset button clicked. Current score: $score")
    }

    private fun checkWinCondition() {
        if (score == 15) {
            mediaPlayerWin.start() //play win sound
            Log.d("WinCheck", "Win Condition Met: $score")
        } else {
            Log.d("WinCheck", "Win Condition Not Met. Score updated: $score")
        }
    }

    private fun updateScore() {
        scoreTextView.text = score.toString() //change on screen score to the actual score
        Log.d("ScoreUpdater", "Score Updated: $score")
    }

    override fun onSaveInstanceState(outState: Bundle) {
        super.onSaveInstanceState(outState)
        outState.putInt("SCORES_KEY", score) //save current score value in bundle
    }

    override fun onDestroy() {
        super.onDestroy()
        mediaPlayerClick.release()
        mediaPlayerWin.release()
    }
}