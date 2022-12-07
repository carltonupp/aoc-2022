defmodule RockPaperScissors do
  @moduledoc """
  Documentation for `RockPaperScissors`.
  """

  @doc """
  Rock Paper Scissors.

  ## Examples

      iex> RockPaperScissors.calculate([{ "A", "Y"}, {"B", "X"}, {"C", "Z"}])
      15

      iex> RockPaperScissors.calculate_with_desired_outcomes([{ "A", "Y"}, {"B", "X"}, {"C", "Z"}])
      12

  """

  def calculate(inputs) do
    inputs
    |> Enum.map(fn x -> calculate_points(x) end)
    |> Enum.sum
  end

  def calculate_with_desired_outcomes(inputs) do
    inputs
    |> Enum.map(fn x -> calculate_outcome(x) end)
    |> Enum.map(fn x -> calculate_points(x) end)
    |> Enum.sum
  end

  defp map_letter_to_atom(letter) do
    case letter do
      l when l in ["A", "X"] -> :rock
      l when l in ["B", "Y"] -> :paper
      l when l in ["C", "Z"] -> :scissors
    end
  end

  defp map_pair_to_atoms(letter_pair) do
    letter_pair
    |> Tuple.to_list()
    |> Enum.map(&map_letter_to_atom/1)
    |> List.to_tuple()
  end

  defp calculate_points(turn) do
    { theirs, ours } = map_pair_to_atoms(turn)
    case { theirs, ours } do
      { :scissors, :rock } -> 6
      { :rock, :paper } -> 6
      { :paper, :scissors } -> 6
      { x, y } when x == y -> 3
      _ -> 0
    end + case ours do
      :rock -> 1
      :paper -> 2
      :scissors -> 3
    end
  end

  defp get_losing_outcome(shape) do
    case shape do
      "A" -> "Z"
      "B" -> "X"
      "C" -> "Y"
    end
  end

  defp get_winning_outcome(shape) do
    case shape do
      "A" -> "Y"
      "B" -> "Z"
      "C" -> "X"
    end
  end

  defp get_drawing_outcome(shape) do
    case shape do
      "A" -> "X"
      "B" -> "Y"
      "C" -> "Z"
    end
  end

  defp calculate_outcome(turn) do
    case turn do
      { theirs, "Y" } -> { theirs, get_drawing_outcome(theirs) }
      { theirs, "X" } -> { theirs, get_losing_outcome(theirs) }
      { theirs, "Z" } -> { theirs, get_winning_outcome(theirs) }
    end
  end

end
