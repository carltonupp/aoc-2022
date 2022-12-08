defmodule RucksackReorganisation do
  @moduledoc """
  Documentation for `RucksackReorganisation`.
  """

  @doc """
  Hello world.

  ## Examples


  """

  def sum_of_priorites rucksacks do
    rucksacks
    |> Enum.map(fn str -> split_string_in_half(str) end)
    |> Enum.map(fn strs -> find_overlaps(strs) end)
    |> Enum.map(fn overlap -> get_char_value(overlap) end)
    |> Enum.sum()
  end

  # Surely there's a better way?
  defp split_string_in_half(str) do
    halfway = round(String.length(str) / 2)
    first = String.slice(str, 0..halfway - 1)
    second = String.slice(str, halfway, halfway)
    { first, second }
  end

  defp find_overlaps(substrings) do
    [str1, str2] = substrings
    |> Tuple.to_list()
    |> Enum.map(fn s -> String.graphemes(s) end)

    intersect(str1, str2) |> List.first()
  end

  defp intersect(list1, list2) do
    Enum.filter(list1, fn x -> Enum.member?(list2, x) end)
  end

  defp add_one(n) do
    n + 1
  end

  defp get_char_value(char) do
    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ"
    |> String.graphemes()
    |> Enum.find_index(fn c -> c == char end)
    |> add_one()
  end
end
