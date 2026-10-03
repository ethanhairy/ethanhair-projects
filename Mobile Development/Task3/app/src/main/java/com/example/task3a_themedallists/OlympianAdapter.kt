package com.example.task3a_themedallists

import android.view.LayoutInflater
import android.view.ViewGroup
import androidx.recyclerview.widget.RecyclerView
import com.example.task3a_themedallists.databinding.ItemRowBinding

data class OlympianData(
    val name: String,
    val country: String,
    val goldMedals: Int,
    val silverMedals: Int,
    val bronzeMedals: Int,
    val flagResId: Int
)

class OlympianAdapter(
    private val olympianList: List<OlympianData>,
    private val onItemClick: (OlympianData) -> Unit
) : RecyclerView.Adapter<OlympianAdapter.OlympianViewHolder>() {

    inner class OlympianViewHolder(val binding: ItemRowBinding) :
        RecyclerView.ViewHolder(binding.root) {
        fun bind(olympian: OlympianData) {
            binding.nameTextView.text = olympian.name
            binding.countryTextView.text = olympian.country
            binding.medalsTextView.text = "Total Medals: ${olympian.goldMedals + olympian.silverMedals + olympian.bronzeMedals}"
            binding.flagImageView.setImageResource(olympian.flagResId) //set the flag image resource
            binding.root.setOnClickListener { onItemClick(olympian) }
        }
    }

    override fun onCreateViewHolder(parent: ViewGroup, viewType: Int): OlympianViewHolder {
        val inflater = LayoutInflater.from(parent.context)
        val binding = ItemRowBinding.inflate(inflater, parent, false)
        return OlympianViewHolder(binding)
    }

    override fun onBindViewHolder(holder: OlympianViewHolder, position: Int) {
        holder.bind(olympianList[position])
    }

    override fun getItemCount(): Int = olympianList.size
}