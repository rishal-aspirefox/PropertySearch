import React from "react";
import type { Property } from "../interfaces/IProperty";
import { useNavigate } from "react-router-dom";

interface PropertyCardProps {
  property: Property;
}

const CARD_HEIGHT = 400;

const PropertyCard: React.FC<PropertyCardProps> = ({ property }) => {
  const imageUrl =
    (property as any).image ||
    "https://img.freepik.com/free-photo/house-isolated-field_1303-23773.jpg?t=st=1755848409~exp=1755852009~hmac=ab42b26eb0b557f3a3a7844467628a0a55e400a372cbaf557cfdb98c171af0b6&w=1480";

  const navigate = useNavigate();

  return (
    <div
      className="card shadow mb-4"
      style={{
        borderRadius: "16px",
        border: "none",
        overflow: "hidden",
        maxWidth: 310,
        minHeight: CARD_HEIGHT,
        height: CARD_HEIGHT,
        display: "flex",
        flexDirection: "column",
      }}
      role="region"
      aria-label={`Property card for ${property.address}`}
    >
      <div style={{ overflow: "hidden" }}>
        <img
          src={imageUrl}
          alt={`Image of property at ${property.address}`}
          className="w-100"
          style={{ objectFit: "cover", height: "100%" }}
        />
      </div>
      <div className="card-body d-flex flex-column justify-content-between">
        <div>
          <h5
            className="card-title mb-1"
              style={{
        fontWeight: 600,
        overflow: 'hidden',
        whiteSpace: 'nowrap',
        textOverflow: 'ellipsis'
      }}
            aria-label={`Property address: ${property.address}`}
          >
            {property.address}
          </h5>
          <span
            className="badge rounded-pill text-bg-danger mb-2"
            aria-label={`Property type: ${property.type}`}
          >
            {property.type}
          </span>
          <h6
            className="mb-2"
            style={{ color: "#2e7d32", fontWeight: 700 }}
            aria-label={`Price: ${property.price?.toLocaleString() ?? "Not available"}`}
          >
            <span>{property.price?.toLocaleString() ?? "N/A"}</span>
          </h6>
          {property.description && (
            <p
              className="mb-2"
              style={{
                fontSize: "0.97em",
                display: "-webkit-box",
                WebkitLineClamp: 2,
                WebkitBoxOrient: "vertical",
                overflow: "hidden",
                textOverflow: "ellipsis",
                whiteSpace: "normal",
              }}
              aria-label={`Description: ${property.description}`}
              title={property.description}
            >
              {property.description}
            </p>
          )}
        </div>
        <div className="mt-1">
          <button
            className="btn btn-sm px-4 shadow-sm"
            onClick={() => navigate(`/property/${property.id}`)}
            style={{ borderRadius: 8, color: "white", backgroundColor: "#5a809b" }}
            aria-label={`View details for property at ${property.address}`}
          >
            View
          </button>
        </div>
      </div>
    </div>
  );
};

export default PropertyCard;
